using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Passport
    {
        public string BirthYear;
        public string IssueYear;
        public string ExpirationYear;
        public string Height;
        public string HairColor;
        public string EyeColor;
        public string PassportId;

        public bool IsValid =>
            BirthYear != null && IssueYear != null && ExpirationYear != null && Height != null && HairColor != null
            && EyeColor != null && PassportId != null;
    }

    public class PassportWithValidations
    {
        private int _birthYear;
        private int _issueYear;
        private int _expirationYear;
        private string _eyeColor;
        private string _passportId;

        public int BirthYear
        {
            get => _birthYear;
            set
            {
                if (value >= 1920 && value <= 2002)
                {
                    _birthYear = value;
                }
            }
        }

        public int IssueYear
        {
            get => _issueYear;
            set
            {
                if (value >= 2010 && value <= 2020)
                {
                    _issueYear = value;
                }
            }
        }
        
        public int ExpirationYear
        {
            get => _expirationYear;
            set
            {
                if (value >= 2020 && value <= 2030)
                {
                    _expirationYear = value;
                }
            }
        }

        private int Height { get; set; }

        public string HairColor { get; set; }

        public string EyeColor
        {
            get => _eyeColor;
            set
            {
                var validHairColors = new[]{"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};

                if (validHairColors.Contains(value))
                {
                    _eyeColor = value;
                }
            }
        }

        public void SetHeight(string heightAsString)
        {
            var measurementType = heightAsString.Substring(heightAsString.Length - 2);

            if (measurementType == "cm")
            {
                var measurement = int.Parse(heightAsString.Substring(0, 3));

                if (measurement >= 150 && measurement <= 193)
                {
                    Height = measurement;
                }
            } else if (measurementType == "in")
            {
                var measurement = int.Parse(heightAsString.Substring(0, 2));
                
                if (measurement >= 59 && measurement <= 76)
                {
                    Height = measurement;
                }
            }
        }

        public string PassportId
        {
            get => _passportId;
            set
            {
                if (value.Length == 9)
                {
                    _passportId = value;
                }
            }
        }

        public bool IsValid =>
            BirthYear != 0 && IssueYear != 0 && ExpirationYear != 0 && Height != 0 && HairColor != null
            && EyeColor != null && PassportId != null;
    }
    
    public static class Day4
    {
        private static readonly string FileName = Path.Combine(Environment.CurrentDirectory, @"inputs/day4.txt");

        public static int PartOne()
        {
            var validPassportsCount = 0;

            var lines = File.ReadAllLines(FileName);
            
            const string birthYearPattern = @"byr:(\S+)";
            const string issueYearPattern = @"iyr:(\S+)";
            const string expirationYearPattern = @"eyr:(\S+)";
            const string heightPattern = @"hgt:(\S+)";
            const string eyeColorPattern = @"ecl:(\S+)";
            const string hairColorPattern = @"hcl:(\S+)";
            const string passportIdPattern = @"pid:(\S+)";
            
            var currentPassport = new Passport();

            foreach (var line in lines)
            {
                if (line.Length == 0)
                {
                    currentPassport = new Passport();
                }
                else
                {
                    foreach (System.Text.RegularExpressions.Match match in System.Text.RegularExpressions.Regex.Matches(
                        line, birthYearPattern))
                    {
                        var birthYear = match.Groups[1].Value;

                        currentPassport.BirthYear = birthYear;
                    }

                    foreach (System.Text.RegularExpressions.Match match in System.Text.RegularExpressions.Regex.Matches(
                        line, issueYearPattern))
                    {
                        var issueYear = match.Groups[1].Value;

                        currentPassport.IssueYear = issueYear;
                    }

                    foreach (System.Text.RegularExpressions.Match match in System.Text.RegularExpressions.Regex.Matches(
                        line, expirationYearPattern))
                    {
                        var expirationYear = match.Groups[1].Value;

                        currentPassport.ExpirationYear = expirationYear;
                    }

                    foreach (System.Text.RegularExpressions.Match match in System.Text.RegularExpressions.Regex.Matches(
                        line, heightPattern))
                    {
                        var height = match.Groups[1].Value;

                        currentPassport.Height = height;
                    }

                    foreach (System.Text.RegularExpressions.Match match in System.Text.RegularExpressions.Regex.Matches(
                        line, eyeColorPattern))
                    {
                        var eyeColor = match.Groups[1].Value;

                        currentPassport.EyeColor = eyeColor;
                    }

                    foreach (System.Text.RegularExpressions.Match match in System.Text.RegularExpressions.Regex.Matches(
                        line, hairColorPattern))
                    {
                        var hairColor = match.Groups[1].Value;

                        currentPassport.HairColor = hairColor;
                    }

                    foreach (System.Text.RegularExpressions.Match match in System.Text.RegularExpressions.Regex.Matches(
                        line, passportIdPattern))
                    {
                        var passportId = match.Groups[1].Value;

                        currentPassport.PassportId = passportId;
                    }
                }

                if (currentPassport.IsValid)
                {
                    validPassportsCount++;
                    
                    currentPassport = new Passport();
                }
            }

            return validPassportsCount;
        }

        public static int PartTwo()
        {
            var validPassportsCount = 0;

            var lines = File.ReadAllLines(FileName);
            
            const string birthYearPattern = @"byr:(\d{4})";
            const string issueYearPattern = @"iyr:(\d{4})";
            const string expirationYearPattern = @"eyr:(\d{4})";
            const string heightPattern = @"hgt:((\d{3}cm)|(\d{2}in))";
            const string eyeColorPattern = @"ecl:(\w{3})";
            const string hairColorPattern = @"hcl:#([0-9a-f]{6})";
            const string passportIdPattern = @"pid:(\d+)";
            
            var currentPassport = new PassportWithValidations();

            foreach (var line in lines)
            {
                if (line.Length == 0)
                {
                    currentPassport = new PassportWithValidations();
                }
                else
                {
                    foreach (System.Text.RegularExpressions.Match match in System.Text.RegularExpressions.Regex.Matches(
                        line, birthYearPattern))
                    {
                        var birthYear = match.Groups[1].Value;

                        currentPassport.BirthYear = int.Parse(birthYear);
                    }

                    foreach (System.Text.RegularExpressions.Match match in System.Text.RegularExpressions.Regex.Matches(
                        line, issueYearPattern))
                    {
                        var issueYear = match.Groups[1].Value;

                        currentPassport.IssueYear = int.Parse(issueYear);
                    }

                    foreach (System.Text.RegularExpressions.Match match in System.Text.RegularExpressions.Regex.Matches(
                        line, expirationYearPattern))
                    {
                        var expirationYear = match.Groups[1].Value;

                        currentPassport.ExpirationYear = int.Parse(expirationYear);
                    }

                    foreach (System.Text.RegularExpressions.Match match in System.Text.RegularExpressions.Regex.Matches(
                        line, heightPattern))
                    {
                        var height = match.Groups[1].Value;
                        
                        currentPassport.SetHeight(height);
                    }

                    foreach (System.Text.RegularExpressions.Match match in System.Text.RegularExpressions.Regex.Matches(
                        line, eyeColorPattern))
                    {
                        var eyeColor = match.Groups[1].Value;

                        currentPassport.EyeColor = eyeColor;
                    }

                    foreach (System.Text.RegularExpressions.Match match in System.Text.RegularExpressions.Regex.Matches(
                        line, hairColorPattern))
                    {
                        var hairColor = match.Groups[1].Value;

                        currentPassport.HairColor = hairColor;
                    }

                    foreach (System.Text.RegularExpressions.Match match in System.Text.RegularExpressions.Regex.Matches(
                        line, passportIdPattern))
                    {
                        var passportId = match.Groups[1].Value;

                        currentPassport.PassportId = passportId;
                    }
                }

                if (currentPassport.IsValid)
                {
                    validPassportsCount++;
                    
                    currentPassport = new PassportWithValidations();
                }
            }

            return validPassportsCount;
        }
    }
}