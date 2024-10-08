# BinaryString Project

This project implements the logic for evaluating binary strings according to specific criteria. It is built using .NET Core.

## Project Structure

- **BinaryStringEvaluator**: This is the main project containing the logic for binary string evaluation.
    - **Entry point**: `Program.cs`
    - **How to run**: 
      ```bash
      cd BinaryStringEvaluator
      dotnet run
      ```

- **BinaryStringEvaluator.Tests**: This project contains unit tests to verify the correctness of the binary string evaluation function.
    - **How to run tests**:
      ```bash
      cd BinaryStringEvaluator.Tests
      dotnet test
      ```

## Functionality

The function evaluates binary strings based on two conditions:
1. The binary string must contain an equal number of '0's and '1's.
2. For every prefix of the string, the number of '1's must not be less than the number of '0's.

## Testing

The project includes unit tests to ensure the correctness of the binary string evaluator. Run the tests using the command mentioned above.