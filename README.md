# Mslm .NET SDK

The official C#/.NET SDK for Mslm APIs.

## Requirements

- .NET Standard 2.0 or above.

## Authentication

Mslm's APIs require an API key. If you don't have one, please read [Authentication](https://mslm.io/docs/api/authentication) to understand how to get an API key before continuing.

## Installation

To install the Mslm .NET SDK, add it to your project via NuGet:

```bash
dotnet add package Mslm
```

## Usage

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

        // OTP send example (use actual phone number).
        var otpSendReq = new OtpSendReq
            {
                Phone = "12345678",
                TmplSms = "This is your OTP",
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

        var response = await mslmClient.EmailVerify.SingleVerify(emailToVerify);
        Console.WriteLine($"Msg: {response.Msg}");
        Console.WriteLine($"Email: {response.Email}");
        Console.WriteLine($"Status: {response.Status}");

        // OTP send example (use actual phone number).
        var otpSendReq = new OtpSendReq
            {
                Phone = "12345678",
                TmplSms = "This is your OTP",
                TokenLen = 6,
                ExpireSeconds = 300
            };

        var response = await mslmClient.Otp.Send(otpSendReq);
        Console.WriteLine($"Code: {response.Code}");
        Console.WriteLine($"Msg: {response.Msg}");

        // OTP token verify example (use actual phone number and token).
        var otpVerifyReq = new OtpTokenVerifyReq
            {
                Phone = "03219427983",
                Token = "406378",
                Consume = true
            };

        var response = await mslmClient.Otp.Verify(otpVerifyReq);
        Console.WriteLine($"Code: {response.Code}");
        Console.WriteLine($"Msg: {response.Msg}");
    }
}
```

## Additional Resources

See the official [API Reference Documentation](https://mslm.io/docs/api) for
details on each API's actual interface, which is implemented by this SDK.

## Contributing

See [CONTRIBUTING](CONTRIBUTING.md) for more information.

## Security

See [Security Issue
Notifications](CONTRIBUTING.md#security-issue-notifications) for more
information.

## License

This project is licensed under the [MIT License](LICENSE).

## About Mslm

At Mslm, we're all about making things better. Where others see norm, we see
opportunity.

We build world-class solutions to the toughest problems. Excellence is a core
value that defines our approach from top to bottom.

We're all about creating positive value for ourselves, our partners and our
societies.

We do it by focusing on quality and the long-term, while intelligently
maneuvering the complex realities of day-to-day business.

Our partners share our perspective, and we jointly produce truly world-class
solutions to the toughest problems.

[![image](https://avatars.githubusercontent.com/u/50307970?s=200&v=4)](https://mslm.io/)
