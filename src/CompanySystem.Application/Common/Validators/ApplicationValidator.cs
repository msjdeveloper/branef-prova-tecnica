using Ardalis.SmartEnum;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace CompanySystem.Application.Common.Validators;

public static class ApplicationValidator
{
    public static bool BeAValidGuid(Guid id)
    {
        return id != Guid.Empty;
    }

    public static bool BeAValidString(string value)
    {
        return !string.IsNullOrEmpty(value) && !int.TryParse(value, out _);
    }

    public static bool BeAValidDate(DateTime? date)
    {
        if (date == null)
            return false;

        if (date.Value.Year < 1 || date.Value.Year > 9999)
            return false;

        return true;
    }

    public static bool BeAValidDate(DateTime date)
    {
        if (date.Year < 1 || date.Year > 9999)
            return false;

        return true;
    }

    public static bool BeAValidZipCode(string zipCode)
    {
        foreach (char c in zipCode)
        {
            if (!char.IsDigit(c))
                return false;
        }

        return true;
    }

    public static bool BeAValidEnumValue<TEnum>(int? value) where TEnum : SmartEnum<TEnum, int>
    {
        if (value == null)
            return false;

        return SmartEnum<TEnum, int>.TryFromValue(value.Value, out _);
    }

    public static bool BeAValidEnumValue<TEnum>(int value) where TEnum : SmartEnum<TEnum, int>
    {
        return SmartEnum<TEnum, int>.TryFromValue(value, out _);
    }

    public static bool BeAValidPdfFiles(List<IFormFile> files)
    {
        foreach (var file in files)
        {
            if (!Path.GetExtension(file.FileName).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
        }

        return true;
    }

    public static bool BeAValidCsvFile(IFormFile file)
    {
        return Path.GetExtension(file.FileName).Equals(".csv", StringComparison.OrdinalIgnoreCase);
    }

    public static bool BeAValidPhone(string? phone)
    {
        if (phone == null)
            return true;

        phone = phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

        if (phone.Length < 10 || phone.Length > 11)
            return false;

        if (new string(phone[0], phone.Length) == phone)
            return false;

        return true;
    }

    public static bool BeAValidOnlyPhone(string phone)
    {
        if (phone.Length < 8 || phone.Length > 9)
            return false;

        if (new string(phone[0], phone.Length) == phone)
            return false;

        return true;
    }

    public static bool BeAValidPassword(string password)
    {
        return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,20}$");
    }

    public static bool BeAValidCredit(int value)
    {
        return value == 0 || value >= 10;
    }

    public static bool BeAValidCpf(string cpf)
    {
        cpf = cpf.Replace(".", "").Replace("-", "");

        if (cpf.Length != 11)
            return false;

        if (new string(cpf[0], 11) == cpf)
            return false;

        int[] multipliers1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multipliers2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int sum;
        int remainder;
        string digit;
        string tempCpf;

        tempCpf = cpf.Substring(0, 9);
        sum = 0;

        for (int i = 0; i < 9; i++)
            sum += int.Parse(tempCpf[i].ToString()) * multipliers1[i];

        remainder = sum % 11;

        if (remainder < 2)
            remainder = 0;
        else
            remainder = 11 - remainder;

        digit = remainder.ToString();
        tempCpf = tempCpf + digit;
        sum = 0;

        for (int i = 0; i < 10; i++)
            sum += int.Parse(tempCpf[i].ToString()) * multipliers2[i];

        remainder = sum % 11;

        if (remainder < 2)
            remainder = 0;
        else
            remainder = 11 - remainder;

        digit = digit + remainder.ToString();

        return cpf.EndsWith(digit);
    }

    public static bool BeAValidCnpj(string cnpj)
    {
        cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

        if (cnpj.Length != 14)
            return false;

        if (new string(cnpj[0], 14) == cnpj)
            return false;

        int[] multipliers1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multipliers2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int sum;
        int remainder;
        string digit;
        string tempCnpj;

        tempCnpj = cnpj.Substring(0, 12);
        sum = 0;

        for (int i = 0; i < 12; i++)
            sum += int.Parse(tempCnpj[i].ToString()) * multipliers1[i];

        remainder = sum % 11;

        if (remainder < 2)
            remainder = 0;
        else
            remainder = 11 - remainder;

        digit = remainder.ToString();
        tempCnpj = tempCnpj + digit;
        sum = 0;

        for (int i = 0; i < 13; i++)
            sum += int.Parse(tempCnpj[i].ToString()) * multipliers2[i];

        remainder = sum % 11;

        if (remainder < 2)
            remainder = 0;
        else
            remainder = 11 - remainder;

        digit = digit + remainder.ToString();

        return cnpj.EndsWith(digit);
    }
}
