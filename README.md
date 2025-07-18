# Iron Software - Sales Engineer position challenge

> Dario Bravo <darbravo@gmail.com>

---

## Details

- CLI - User interacts with the OldPhonePad implementation through a command line console application
- Testing - Unit testing is implemented for input validation, tokenization and decoding
- Git Repo: https://github.com/darbravo/is

---

## Build

```bash
$ cd IronSoftware.OldPhoneApp.Cli
$ dotnet build
$ cd bin/Debug/net8.0
$ ./OldPhoneApp 
Iron Software - Sales Engineer role challenge
Dario Bravo <darbravo@gmail.com>

Type 'quit' to quit.
> 
```

---

# Usage

To get OldPhonePad on another app, import the `IronSoftware.OldPhoneApp.Models` class library.

```csharp
InputValidator.Validate(input); // optional but recommended to validate input
var tokens = Tokenizer.Tokenize(input); // 1st - tokenize the input string
return OldPhoneAppDecoder.Decode(tokens); // 2nd - decode
```

## Command Line

```bash
$ ./OldPhoneApp 
Iron Software - Sales Engineer role challenge
Dario Bravo <darbravo@gmail.com>

Type 'quit' to quit.
> 8 88777444666*664#
TURING
```
