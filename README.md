# OldPhoneSolution
Iron Software - Software Sales Engineer Application

This C# console application simulates typing on an old mobile phone keypad, where each digit key maps to multiple letters (e.g., `2` maps to `A`, `B`, `C`).

## 📋 Key Features

- Converts digit sequences to letters using T9-style input.
- Handles:
  - `*` as a backspace key.
  - `#` as an "enter" key (end of input).
  - Space (`' '`) as a pause between characters.


## 🛠️ How to Use

1. Run the program.
2. Input a string of numbers that simulates old phone keypad presses.
3. End input with `#`.
4. Press Enter.


## 📌 Rules

|Key  | Letters  |
|-----|----------|
| 2   | A B C    |
| 3   | D E F    |
| 4   | G H I    |
| 5   | J K L    |
| 6   | M N O    |
| 7   | P Q R S  |
| 8   | T U V    |
| 9   | W X Y Z  |
| 0   | (space)  |
| *   | Backspace |
| #   | End input |


## 🧪 Test Cases
Inputs                     |        Outputs
33#                        =>          E
227*#                      =>          B
4433555 555666#            =>        HELLO
8 88777444666*664#         =>        TURING



## 🧑‍💻 Applicant
Submitted by Jim Paul Niñeria 

