# DateTimeHelper

## Overview

`DateTimeHelper` is a static class that provides utility methods for working with dates. It includes methods to convert Gregorian dates to Hijri dates and to calculate the difference between two dates in various units.

## Methods

### `ToHijriDate`

Converts a Gregorian date to a Hijri date.

**Signature:**
```csharp
public static string ToHijriDate(this DateTime gregorianDate)
```

**Parameters:**
- `gregorianDate` (DateTime): The Gregorian date to convert.

**Returns:**
- `string`: The corresponding Hijri date.

**Remarks:**
This method uses the `UmAlQuraCalendar` to perform the conversion.

### `DateDiff`

Calculates the difference between two dates in years, months, days, hours, minutes, and seconds.

**Signature:**
```csharp
public static (int years, int months, int days, int hours, int minutes, int seconds) DateDiff(this DateTime firstDate, DateTime secondDate)
```

**Parameters:**
- `firstDate` (DateTime): The first date.
- `secondDate` (DateTime): The second date.

**Returns:**
- `(int years, int months, int days, int hours, int minutes, int seconds)`: The difference between the two dates.

**Remarks:**
This method compares the two dates and calculates the difference in years, months, days, hours, minutes, and seconds.

## Usage

```csharp
using DateTimeHelper;

// Convert Gregorian date to Hijri date
DateTime gregorianDate = new DateTime(2023, 10, 1);
string hijriDate = gregorianDate.ToHijriDate();
Console.WriteLine($"Hijri Date: {hijriDate}");

// Calculate the difference between two dates
DateTime firstDate = new DateTime(2023, 1, 1);
DateTime secondDate = new DateTime(2023, 10, 1);
var dateDifference = firstDate.DateDiff(secondDate);
Console.WriteLine($"Difference: {dateDifference.years} years, {dateDifference.months} months, {dateDifference.days} days, {dateDifference.hours} hours, {dateDifference.minutes} minutes, {dateDifference.seconds} seconds");
```

## License

This project is licensed under the MIT License.
