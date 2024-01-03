# Mslm Dotnet SDK

The official C#/Dotnet SDK for Mslm APIs.

## Requirements

- .NET Standard 2.0 or above.

## Installation

To install the Mslm Dotnet SDK, add it to your project via NuGet:

```bash
dotnet add package Mslm
```

## Setting Up

Ensure you have a .NET project. If not, you can start a new one:

```bash
dotnet new console -n YourProjectName
cd YourProjectName
```

Install the package:

```bash
dotnet add package Mslm
```

Reference the package's main entrypoint in your program and write some code
using individual SDK clients:

```cs
using System;
using Mslm.EmailVerifyNS;
using Mslm.OtpNS;

class Program
{
    static void Main(string[] args)
    {
        // Email verification example.
        var emailVerifyClient = new EmailVerify("MSLM_API_KEY");
        string emailToVerify = "abc@gmail.com";

        var response = await emailVerifyClient.SingleVerify(emailToVerify);
        Console.WriteLine($"Msg: {response.Msg}");
        Console.WriteLine($"Email: {response.Email}");
        Console.WriteLine($"Status: {response.Status}");

        // Otp send example (use actual phone number).
        var otpSendReq = new OtpSendReq
            {
                Phone = "12345678",
                TmplSms = "This is your Otp",
                TokenLen = 6,
                ExpireSeconds = 300
            };

        var otpSendClient = new Otp("MSLM_API_KEY");
        var response = await otpSendClient.Send(otpSendReq);
        Console.WriteLine($"Code: {response.Code}");
        Console.WriteLine($"Msg: {response.Msg}");

        // Otp token verify example (use actual phone number and token).
        var otpVerifyReq = new OtpTokenVerifyReq
            {
                Phone = "03219427983",
                Token = "406378",
                Consume = true
            };

        var otpVerifyClient = new Otp("MSLM_API_KEY");
        var response = await otpVerifyClient.Verify(otpVerifyReq);
        Console.WriteLine($"Code: {response.Code}");
        Console.WriteLine($"Msg: {response.Msg}");
    }
}

```

Or you can reference the global Mslm SDK client instead of individually
initializing each client:

```cs
using System;
using Mslm.MslmNS;

class Program
{
    static void Main(string[] args)
    {
		// Initialize Mslm Client.
        mslmClient = new MslmClient("MSLM_API_KEY");

        // Email verification example.
        string emailToVerify = "abc@gmail.com";

        var response = await mslmClient.EmailVerifyClient.SingleVerify(emailToVerify);
        Console.WriteLine($"Msg: {response.Msg}");
        Console.WriteLine($"Email: {response.Email}");
        Console.WriteLine($"Status: {response.Status}");

        // Otp send example (use actual phone number).
        var otpSendReq = new OtpSendReq
            {
                Phone = "12345678",
                TmplSms = "This is your Otp",
                TokenLen = 6,
                ExpireSeconds = 300
            };

        var response = await mslmClient.OtpClient.Send(otpSendReq);
        Console.WriteLine($"Code: {response.Code}");
        Console.WriteLine($"Msg: {response.Msg}");

        // Otp token verify example (use actual phone number and token).
        var otpVerifyReq = new OtpTokenVerifyReq
            {
                Phone = "03219427983",
                Token = "406378",
                Consume = true
            };

        var response = await mslmClient.OtpClient.Verify(otpVerifyReq);
        Console.WriteLine($"Code: {response.Code}");
        Console.WriteLine($"Msg: {response.Msg}");
    }
}

```

## About Mslm

mslm focuses on producing world-class business solutions. It’s the
bread-and-butter of our business to prioritize quality on everything we touch.
Excellence is a core value that defines our culture from top to bottom.

[![image](https://avatars.githubusercontent.com/u/50307970?s=200&v=4)](https://mslm.io/)