using Application.Abstractions.CustomExceptions.Abstractions.StatusCodeCustomExceptions;
using Application.Abstractions.CustomExceptions.Products;
using Application.Abstractions.CustomExceptions.PromoCode;
using Application.Abstractions.Services.ShopServices.HandlerServices;
using Application.Abstractions.Services.ShopServices.ValidationServices;
using Application.DTOs.PromoCode;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Services.ShopServices.HandlerServices;

public class PromoCodeHandlerService : IPromoCodeHandlerService
{
    private readonly IPromoCodeRepository _promoCodeRepository;
    private readonly IMapper _mapper;

    public PromoCodeHandlerService(IPromoCodeRepository promoCodeRepository, IMapper mapper)
    {
        _promoCodeRepository = promoCodeRepository;
        _mapper = mapper;
    }

    public async Task Create(PromoCodeAddDto promoCodeAddDto)
    {
        var promoCode = _mapper.Map<PromoCode>(promoCodeAddDto);

        var timeNotParsed = promoCodeAddDto.TimeNotParsed;
        var expireDate = promoCode.CreatedAt.Add(ParseTime(timeNotParsed));
        promoCode.ExpiresAt = expireDate;
        
        await _promoCodeRepository.AddAsync(promoCode);
    }

    public async Task<bool> Activate(int id)
    {
        var promoCode = await _promoCodeRepository.GetByIdAsync(id);

        ValidatePromoCode(promoCode, false);

        return await Activate(promoCode!);
    }

    public async Task<bool> Activate(string code)
    {
        var allPromoCodes = await _promoCodeRepository.GetAllAsync();
        var promoCode = allPromoCodes.FirstOrDefault(i => i.Code.Equals(code));

        ValidatePromoCode(promoCode, false);

        return await Activate(promoCode!);
    }

    public async Task<bool> Deactivate(int id)
    {
        var promoCode = await _promoCodeRepository.GetByIdAsync(id);

        ValidatePromoCode(promoCode, true);

        return await Deactivate(promoCode!);
    }

    public async Task<bool> Deactivate(string code)
    {
        var allPromoCodes = await _promoCodeRepository.GetAllAsync();
        var promoCode = allPromoCodes.FirstOrDefault(i => i.Code.Equals(code));

        ValidatePromoCode(promoCode, true);

        return await Deactivate(promoCode!);
    }

    public async Task<double> TryUse(string code)
    {
        var allPromoCodes = await _promoCodeRepository.GetAllAsync();
        var promoCode = allPromoCodes.FirstOrDefault(i => i.Code.Equals(code));

        ValidatePromoCode(promoCode, true, true);

        if (promoCode!.LimitOfUsages <= promoCode.Usages)
        {
            await Deactivate(promoCode);
            throw new WrongPromoCodeException("PromoCode is not available");
        }

        if (promoCode.ExpiresAt < DateTime.Now)
        {
            await Deactivate(promoCode);
            throw new WrongPromoCodeException("PromoCode is not available");
        }

        var discount = promoCode.Discount;
        promoCode.Usages++;

        if (promoCode.LimitOfUsages == promoCode.Usages)
            await Deactivate(promoCode);

        return discount;
    }

    private async Task<bool> Activate(PromoCode promoCode)
    {
        promoCode.IsActive = true;
        var result = await _promoCodeRepository.Update(promoCode);

        return result;
    }

    private async Task<bool> Deactivate(PromoCode promoCode)
    {
        promoCode.IsActive = false;
        var result = await _promoCodeRepository.Update(promoCode);

        return result;
    }

    private void ValidatePromoCode(PromoCode? promoCode, bool shouldBeActive, bool tryingToUse = false)
    {
        if (promoCode is null)
            throw new WrongPromoCodeException("PromoCode was not found");
        
        if (promoCode.IsActive == shouldBeActive) return;

        if (tryingToUse)
            throw new WrongPromoCodeException("PromoCode is not available");
        
        if (shouldBeActive)
            throw new ConflictPromoCodeException("PromoCode is not active");

        throw new ConflictException("PromoCode is already active");
    }

    private TimeSpan ParseTime(string timeNotParsed)
    {
        var timeSpan = new TimeSpan();

        var timeDict = new Dictionary<char, int>
        {
            { 'h', 0 }, { 'd', 0 }, { 'w', 0 }, { 'm', 0 }, { 'y', 0 }
        };

        var timeSplit = timeNotParsed.Split(' ');

        foreach (var timePart in timeSplit)
        {
            var maxIndex = timePart.Length - 1;
            if (!timeDict.ContainsKey(timePart[maxIndex]))
                throw new InvalidPromoCodeException("Wrong time");

            if (!int.TryParse(timePart.AsSpan(0, maxIndex), out var num))
                throw new InvalidPromoCodeException("Wrong time");

            if (num <= 0)
                throw new InvalidPromoCodeException("Wrong time");

            timeDict[timePart[maxIndex]] = num;
        }
        
        foreach (var (key, value) in timeDict)
        {
            switch (key)
            {
                case 'h':
                {
                    var hourTimeSpan = TimeSpan.FromHours(value);
                    timeSpan = timeSpan.Add(hourTimeSpan);
                    break;
                }
                case 'd':
                {
                    var dayTimeSpan = TimeSpan.FromDays(value);
                    timeSpan = timeSpan.Add(dayTimeSpan);
                    break;
                }
                case 'w':
                {
                    var weekTimeSpan = TimeSpan.FromDays(value * 7);
                    timeSpan = timeSpan.Add(weekTimeSpan);
                    break;
                }
                case 'm':
                {
                    var monthTimeSpan = TimeSpan.FromDays(value * 30);
                    timeSpan = timeSpan.Add(monthTimeSpan);
                    break;
                }
                case 'y':
                {
                    var yearTimeSpan = TimeSpan.FromDays(value * 365);
                    timeSpan = timeSpan.Add(yearTimeSpan);
                    break;
                }
            }
        }
        Console.WriteLine(timeSpan);
        return timeSpan;
    }
}