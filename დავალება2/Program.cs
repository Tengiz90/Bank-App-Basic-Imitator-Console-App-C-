using System;
using System.Reflection;

var userName = "user2025";
var password = "pass123";
var balanceInGel = 3000m;
var dailyLimit = 10000m;
var cardNumber = "4111222233334444";

var pinCode = "0000";


var transactionHistory = new List<string>();

var moneyInGELUsedToday = 0m;

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Hello Dear User!");
Console.ResetColor();

Console.WriteLine();



var loginCredentials = GetLogincredentials();
while (!AreLoginCredentialsValid(loginCredentials.inputUserName, loginCredentials.inputPassword))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Entered Username or Password do not match any registered user!");
    Console.ResetColor();

    Console.WriteLine("Try again.");
    loginCredentials = GetLogincredentials();
}

Console.Clear();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Login Successful");
Console.ResetColor();



while (true)
{
    var chosenOperation = chooseOperation();
    var wasOperationcancelled = false;
    Console.Clear();
    switch (chosenOperation)
    {
        case 1:
            {
                DisplayBalance();
                wasOperationcancelled = false;
                break;
            }
        case 2:
            {
                WithdrawMoney();
                wasOperationcancelled = false;
                break;
            }
        case 3:
            {
                AddMoneyToBalance();
                wasOperationcancelled = false;
                break;
            }
        case 4:
            {
                OpenTransferMoney();
                wasOperationcancelled = false;
                break;
            }
        case 5:
            {
                MobileTopUp();
                wasOperationcancelled = false;
                break;
            }

        case 6:
            {
                PayForElectricity();
                wasOperationcancelled = false;
                break;
            }
        case 7:
            {
                PayForWater();
                wasOperationcancelled = false;
                break;
            }
        case 8:
            {
                wasOperationcancelled = PayCleaningFee();
                break;
            }
        case 9:
            {
                wasOperationcancelled = OpenDeposit();
                break;
            }
        case 10:
            {
                OpenLoanCalculator();
                wasOperationcancelled = false;
                break;
            }
        case 11:
            {
                ShowCardInfo();
                wasOperationcancelled = false;
                break;
            }
        case 12:
            {
                ChangePinCode();
                wasOperationcancelled = false;
                break;
            }
        case 13:
            {
                ShowTransactionHistory();
                wasOperationcancelled = false;
                break;
            }
        case 14:
            {
                ShowContactInformation();
                wasOperationcancelled = false;
                break;
            }
        case 15:
            {
                Console.WriteLine("Enter gift card code or 'exit' into menu by typing exit");
                var inputString = Console.ReadLine();
                while (inputString!.Trim().ToLower() != $"{"bonus2025".Trim().ToLower()}" && inputString != $"{"gift100".Trim().ToLower()}" && inputString != $"{"exit".Trim().ToLower()}")
                {
                    Console.WriteLine("Enter gift card code or 'exit' into menu by typing exit");
                    inputString = Console.ReadLine();
                }

                if (inputString!.Trim().ToLower() == "bonus2025")
                {
                    AddMoneyToBalanceViaGiftCardCode(50m);
                    wasOperationcancelled = false;
                }
                else if (inputString!.Trim().ToLower() == "gift100")
                {
                    AddMoneyToBalanceViaGiftCardCode(100m);
                    wasOperationcancelled = false;
                }
                else
                {
                    wasOperationcancelled = true;
                }


                break;
            }
        case 16:
            {
                Console.WriteLine("Are you sure that you want to exit?");
                Console.WriteLine("Type 'yes' or 'no'.");
                var inputString = Console.ReadLine();
                while (inputString!.Trim().ToLower() != $"{"yes".Trim().ToLower()}" && inputString != $"{"no".Trim().ToLower()}")
                {
                    Console.WriteLine("Type yes or no.");
                    inputString = Console.ReadLine();
                }
                if (inputString.Trim().ToLower() == "yes") Environment.Exit(Environment.ExitCode);
                else continue;

                wasOperationcancelled = false;
                break;
            }
    }

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;


    foreach (char c in $"Operation {(wasOperationcancelled ? "cancelled" : "finished")}")
    {
        Console.Write(c);
        Thread.Sleep(30);
    }
    Console.ResetColor();
    Console.WriteLine();

}

(string inputUserName, string inputPassword) GetLogincredentials()
{
    Console.WriteLine("Enter your username:");
    var inputUserName = Console.ReadLine();
    while (inputUserName == null || inputUserName.Trim() == "")
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("UserName can't be empty!");
        Console.ResetColor();

        Console.WriteLine("Enter your username:");
        inputUserName = Console.ReadLine();

    }
    Console.WriteLine("Enter your password:");
    var inputPassword = Console.ReadLine();

    while (inputPassword == null || inputPassword.Trim() == "")
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Password can't be empty!");
        Console.ResetColor();

        Console.WriteLine("Enter your password:");
        inputPassword = Console.ReadLine();

    }

    return (inputUserName!, inputPassword!);

}

bool AreLoginCredentialsValid(string inputUserName, string inputPassword)
{
    if (inputUserName == userName && inputPassword == password)
    {
        return true;
    }
    return false;
}

int chooseOperation()
{
    Console.WriteLine("Select an operation number.");


    listAllOperations();

    int selectedOptionNumber = 0;
    while (!int.TryParse(new string(Console.ReadLine().Where(item => char.IsDigit(item)).ToArray()), out selectedOptionNumber) || selectedOptionNumber < 1 || selectedOptionNumber > 20)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You must enter a number between 1 and 19!");
        Console.ResetColor();
        Console.WriteLine("Select an operation number.");

        listAllOperations();
    }


    return selectedOptionNumber;
}

void listAllOperations()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("1. See your balance.");
    Console.WriteLine("2. Withdraw money from the balance.");
    Console.WriteLine("3. Add funds to balance.");
    Console.WriteLine("4. Transfer money.");
    Console.WriteLine("5. Add funds to your mobile number.");
    Console.WriteLine("6. Pay for electricity.");
    Console.WriteLine("7. Pay for water.");
    Console.WriteLine("8. Pay the cleaning fee.");
    Console.WriteLine("9. Open a deposit.");
    Console.WriteLine("10. Loan calculator.");
    Console.WriteLine("11. Card information.");
    Console.WriteLine("12. Change Pin code.");
    Console.WriteLine("13. Transaction history.");
    Console.WriteLine("14. Contact information.");
    Console.WriteLine("15. Activate gift card code.");
    Console.WriteLine("16. Exit.");
    Console.ResetColor();
}

void DisplayBalance()
{
    Console.WriteLine("=== Balance ===");
    Console.WriteLine($"Balance in Gel - {balanceInGel}");
    Console.WriteLine($"Balance in Dollars - {Math.Round(balanceInGel / 2.70m, 2)}");
    Console.WriteLine($"Balance in Euros - {Math.Round(balanceInGel / 3m, 2)}");
    Console.WriteLine($"Balance in Pounds - {Math.Round(balanceInGel / 3.5m, 2)}");
}

void WithdrawMoney()
{
    Console.WriteLine($"Enter amount in GEL to withdraw, ({balanceInGel} GEL available):");
    decimal amountToWithdraw = 0m;

    var inputIsValid = false;
    while (!inputIsValid)
    {
        if (!decimal.TryParse(Console.ReadLine(), out amountToWithdraw))
        {
            Console.WriteLine("Enter an amount number (in GEL):");
            continue;
        }
        if (amountToWithdraw < 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You can't withdraw negative amount of money.");
            Console.ResetColor();
            Console.WriteLine("Enter an amount number (in GEL):");
            continue;
        }
        if (amountToWithdraw > balanceInGel)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You can't withdraw more than your balance.");
            Console.ResetColor();
            Console.WriteLine("Enter an amount number (in GEL):");
            continue;

        }

        if (moneyInGELUsedToday + amountToWithdraw > dailyLimit)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You can't withdraw that amount because total amount spent used today would exceed your daily limit");
            Console.ResetColor();

            if (balanceInGel >= (dailyLimit - moneyInGELUsedToday))
            {
                Console.WriteLine($"You can only withdraw - {dailyLimit - moneyInGELUsedToday}");
            }
            else Console.WriteLine($"You can only withdraw {balanceInGel} lari");
            Console.WriteLine("Enter an amount number (in GEL):");
            continue;
        }
        inputIsValid = true;
    }


    balanceInGel = balanceInGel - amountToWithdraw;
    Console.WriteLine($"Money withdrawn - {amountToWithdraw}.");


    moneyInGELUsedToday += amountToWithdraw;
    transactionHistory.Add($"Withdrawn - {amountToWithdraw}GEL");

}

void AddMoneyToBalance()
{
    Console.WriteLine($"Enter amount in GEL to add to balance:");
    decimal amountToAdd = 0m;
    while (!decimal.TryParse(Console.ReadLine(), out amountToAdd))
    {
        Console.WriteLine("Enter an amount number (in GEL):");
    }
    balanceInGel = balanceInGel + amountToAdd;
    Console.WriteLine($"Money Added - {amountToAdd}.");
    Console.WriteLine($"Total balance - {balanceInGel}");

    transactionHistory.Add($"Added - {amountToAdd}GEL");
}

void OpenTransferMoney()
{
    Console.WriteLine("=== Money Transfer ===");
    Console.WriteLine("Enter your pin:");
    var userInput = Console.ReadLine();
    if (userInput != pinCode)
    {
        Console.WriteLine("Wrong pin, returning to main menu...");
        return;
    }
    else
    {
        Console.WriteLine("Enter recipient's card number");
        var cardNumberOfRecipient = Console.ReadLine();
        while (cardNumberOfRecipient == null || cardNumberOfRecipient.Replace(" ", "").Length != 16)
        {
            Console.WriteLine("Recipient's card number should be 16 digits long.");
            cardNumberOfRecipient = Console.ReadLine();
        }

        Console.WriteLine("How much money would you like to transfer?");
        decimal amountToTransfer = 0m;

        var inputIsValid = false;
        while (!inputIsValid)
        {
            if (!decimal.TryParse(Console.ReadLine(), out amountToTransfer))
            {
                Console.WriteLine("Enter an amount number (in GEL):");
                continue;
            }
            if (amountToTransfer < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You can't transfer negative amount of money.");
                Console.ResetColor();
                Console.WriteLine("Enter an amount number (in GEL): ");
                continue;
            }
            if (amountToTransfer > balanceInGel)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You can't transfer more than your balance.");
                Console.ResetColor();
                Console.WriteLine("Enter an amount number (in GEL): ");
                continue;
            }
            if (moneyInGELUsedToday + amountToTransfer > dailyLimit)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You can't transfer that amount because total amount spent used today would exceed your daily limit");
                Console.ResetColor();
                if (balanceInGel >= (dailyLimit - moneyInGELUsedToday))
                {
                    Console.WriteLine($"You can only transfer - {dailyLimit - moneyInGELUsedToday}");
                }
                else Console.WriteLine($"You can only transfer {balanceInGel} dollars");
                Console.WriteLine("Enter an amount number (in GEL):");
                continue;
            }
            inputIsValid = true;
        }

        balanceInGel = balanceInGel - amountToTransfer;
        Console.WriteLine($"Money transfered - {amountToTransfer}.");

        moneyInGELUsedToday += amountToTransfer;
        transactionHistory.Add($"transfer to {cardNumberOfRecipient.Replace(" ", "")} - {amountToTransfer}GEL");
    }
}

void MobileTopUp()
{
    Console.WriteLine("=== Mobile Top-Up ===");
    Console.WriteLine("1. Magti");
    Console.WriteLine("2. Silknet");
    Console.WriteLine("3. Beeline");
    Console.WriteLine("Choose provider (1, 2 or 3):");

    int provider = 0;
    while (!int.TryParse(Console.ReadLine(), out provider) || (provider != 1 && provider != 2 && provider != 3))
    {
        Console.WriteLine("Choose provider (1, 2 or 3):");
        continue;
    }

    string number = "";
    do
    {
        Console.WriteLine("Enter a mobile number (9 digits, starting with 5): ");
        number = Console.ReadLine();
    }
    while (number == null);

    number = number.Replace(" ", "");
    while (!int.TryParse(number, out _) || number![0] != '5' || number.Length != 9)
    {
        Console.WriteLine("Enter a mobile number");
        number = Console.ReadLine();
    }


    decimal amountToAddToMobile = 0m;
    var inputIsValid = false;
    while (!inputIsValid)
    {
        Console.WriteLine("Enter an amount number (in GEL):");
        if (!decimal.TryParse(Console.ReadLine(), out amountToAddToMobile))
        {

            continue;
        }
        if (amountToAddToMobile < 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You can't withdraw negative amount of money.");
            Console.ResetColor();

            continue;
        }
        if (amountToAddToMobile > balanceInGel)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You can't withdraw more than your balance.");
            Console.ResetColor();

            continue;

        }

        if (moneyInGELUsedToday + amountToAddToMobile > dailyLimit)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You can't withdraw that amount because total amount spent used today would exceed your daily limit");
            Console.ResetColor();

            if (balanceInGel >= (dailyLimit - moneyInGELUsedToday))
            {
                Console.WriteLine($"You can only add to mobile - {dailyLimit - moneyInGELUsedToday}");
            }
            else Console.WriteLine($"You can only add to mobile {balanceInGel} lari");

            continue;
        }
        inputIsValid = true;
    }


    balanceInGel = balanceInGel - amountToAddToMobile;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Money - {amountToAddToMobile} was successfully added to the mobile.");
    Console.ResetColor();

    moneyInGELUsedToday += amountToAddToMobile;
    transactionHistory.Add($"Added to {number} - {amountToAddToMobile}GEL");


}

bool PayForElectricity()
{

    Console.WriteLine("=== Pay for Electricity ===");


    Console.WriteLine("Enter your subscriber code (10 digits):");
    var subscriberCode = Console.ReadLine()!;
    while (subscriberCode.Length != 10 || !subscriberCode.All(char.IsDigit))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid subscriber code. It must be exactly 10 digits.");
        Console.ResetColor();
        subscriberCode = Console.ReadLine()!;
    }


    Console.WriteLine("Enter your meter reading (in kWh):");
    decimal meterReading = 0m;
    while (!decimal.TryParse(Console.ReadLine(), out meterReading) || meterReading < 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid meter reading. Enter a positive number.");
        Console.ResetColor();
    }


    decimal amountToPay = meterReading * 0.25m;


    if (amountToPay > balanceInGel)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Insufficient balance to pay for electricity.");
        Console.ResetColor();
        return true;
    }

    if (moneyInGELUsedToday + amountToPay > dailyLimit)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You can't pay the bill because total amount spent today would exceed your daily limit.");
        Console.ResetColor();

        return true;
    }

    balanceInGel -= amountToPay;
    moneyInGELUsedToday += amountToPay;
    transactionHistory.Add($"Electricity payment - {amountToPay} GEL, Subscriber: {subscriberCode}");

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Payment successful! Amount paid: {amountToPay:F2} GEL");
    Console.WriteLine($"Remaining balance: {balanceInGel:F2} GEL");
    Console.ResetColor();
    return false;

}

bool PayForWater()
{
    Console.WriteLine("=== Pay for Water ===");


    Console.WriteLine("Enter your subscriber code (10 digits):");
    string subscriberCode = Console.ReadLine();
    while (subscriberCode == null)
    {
        Console.WriteLine("A subscriber code can't be empty, please enter subscriber code (10 digits):");
        subscriberCode = Console.ReadLine();
    }
    while (subscriberCode.Replace(" ", "").Length != 10 || !subscriberCode.Replace(" ", "").All(char.IsDigit))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid subscriber code. It must be exactly 10 digits.");
        Console.ResetColor();
        subscriberCode = Console.ReadLine()!;
    }


    Console.WriteLine("Enter the water usage (in cubic meters):");
    decimal cubicMeters = 0m;
    while (!decimal.TryParse(Console.ReadLine(), out cubicMeters) || cubicMeters < 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid input. Enter a positive number.");
        Console.ResetColor();
    }


    decimal amountToPay = cubicMeters * 0.80m;


    if (amountToPay > balanceInGel)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Insufficient balance to pay for water.");
        Console.ResetColor();
        return true;
    }

    if (moneyInGELUsedToday + amountToPay > dailyLimit)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You can't pay the bill because total amount spent today would exceed your daily limit.");
        Console.ResetColor();

        return true;
    }



    balanceInGel -= amountToPay;
    moneyInGELUsedToday += amountToPay;
    transactionHistory.Add($"Water payment - {amountToPay} GEL, Subscriber: {subscriberCode.Replace(" ", "")}");

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Payment successful! Amount paid: {amountToPay:F2} GEL");
    Console.ResetColor();

    Console.WriteLine($"Remaining balance: {balanceInGel:F2} GEL");
    return false;
}

bool PayCleaningFee()
{

    const decimal monthlyFee = 5m; 
    string input = "";

    Console.WriteLine("Enter number of months to pay cleaning fee (or type 'exit' to cancel):");

    
    while ((input = Console.ReadLine()?.Trim().ToLower()) != "exit")
    {
        if (int.TryParse(input, out int months) && months > 0)
        {
            decimal totalToPay = months * monthlyFee;


            Console.WriteLine($"Total cleaning fee to pay for {months} month(s): {totalToPay} GEL");
            

            if (moneyInGELUsedToday + totalToPay > dailyLimit)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You can't pay the bill because total amount spent today would exceed your daily limit.");
                Console.ResetColor();

                return true;
            }

            balanceInGel -= totalToPay;
            moneyInGELUsedToday += totalToPay;
            transactionHistory.Add($"Cleaning payment - {totalToPay} GEL.");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Payment successful! Amount paid: {totalToPay:F2} GEL");
            Console.WriteLine($"Remaining balance: {balanceInGel:F2} GEL");
            Console.ResetColor();
            return false;
           
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid input. Enter a positive number of months or type 'exit' to cancel.");
        Console.ResetColor();
    }

    return true;
}


bool OpenDeposit()
{

    Console.WriteLine("=== Deposit Opening ===");

    int[] allowedTerms = { 3, 6, 9, 12 };

    PrintMessageForPromptingForAllowedTerms(allowedTerms);
    Console.WriteLine(" | Or type 'exit' to cancel and go to main menu):");

    var term = 0;

    var input = Console.ReadLine();
    if (input != null && input.Trim().ToLower() == "exit")
    {
        return true;
    }

    while (!int.TryParse(input, out term) || !allowedTerms.Contains(term))
    {

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid term.");
        Console.ResetColor();

        PrintMessageForPromptingForAllowedTerms(allowedTerms);
        Console.WriteLine("| or type 'exit' to cancel and go to main menu):");

        input = Console.ReadLine();
        if (input != null && input.Trim().ToLower() == "exit")
        {
            return true;
        }

    }

    var amount = 0m;
    Console.WriteLine("Enter deposit amount (minimum 100 GEL): ");
    while (!decimal.TryParse(Console.ReadLine(), out amount) || amount < 100)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid amount. Must be at least 100 GEL.");
        Console.ResetColor();
        Console.WriteLine("Enter deposit amount (minimum 100 GEL):");
    }


    decimal interestRate = term switch
    {
        3 => 8,
        6 => 10,
        9 => 11,
        12 => 12,
        _ => 0
    };

    Console.WriteLine($"Interest rate for {term} months: {interestRate}%");


    decimal profit = amount * interestRate / 100;
    Console.WriteLine($"Your expected profit: {profit:F2} GEL");

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Deposit opened successfully! Total amount at maturity: {amount + profit:F2} GEL");
    Console.ResetColor();
    return false;
}

void PrintMessageForPromptingForAllowedTerms(int[] allowedTerms)
{
    Console.Write("Enter deposit term (");
    int i;
    for (i = 0; i < allowedTerms.Count() - 1; i++)
    {
        Console.Write(allowedTerms[i] + " ");
    }
    Console.Write($"{allowedTerms[i]} months)");
}
void OpenLoanCalculator()
{
    Console.WriteLine("=== Loan Calculator ===");
    decimal loanAmount = 0m;
    Console.Write("Enter the loan amount ");


    while (!decimal.TryParse(Console.ReadLine(), out loanAmount) || loanAmount <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid loan amount.");
        Console.ResetColor();
        Console.WriteLine("Enter the loan amount:");

    }


    int months = 0;
    Console.WriteLine("Enter the loan term in months:");

    while (!int.TryParse(Console.ReadLine(), out months) || months <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid term.");
        Console.ResetColor();
        Console.WriteLine("Enter the loan term (in months):");

    }

    decimal annualInterestRate = 0m;
    Console.WriteLine("Enter the annual interest rate (%):");

    while (!decimal.TryParse(Console.ReadLine(), out annualInterestRate) || annualInterestRate < 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid interest rate.");
        Console.ResetColor();
        Console.WriteLine("Enter the annual interest rate (%):");

    }


    decimal monthlyRate = annualInterestRate / 12 / 100;


    decimal monthlyPayment;
    if (monthlyRate > 0)
    {
        monthlyPayment = loanAmount *
                         (monthlyRate * (decimal)Math.Pow((double)(1 + monthlyRate), months)) /
                         ((decimal)Math.Pow((double)(1 + monthlyRate), months) - 1);
    }
    else
    {
        monthlyPayment = loanAmount / months;
    }


    decimal totalPayment = monthlyPayment * months;


    Console.WriteLine($"Monthly payment: {monthlyPayment:F2}");
    Console.WriteLine($"Total payment: {totalPayment:F2}");

}
void ShowCardInfo()
{
    Console.WriteLine("=== Card Information ===");
    Console.WriteLine("Card number - 4111 1111 0003 4444");
    Console.WriteLine("Card type - Visa");
    Console.WriteLine("In effect till 12/2027");
    Console.WriteLine($"Daily limit - {dailyLimit} GEL");
    Console.WriteLine($"Money used today (in GEL) - {moneyInGELUsedToday} GEL");
}

void ChangePinCode()
{
    var newPinCode = 0;

    firstPinInput:
    Console.WriteLine("Enter new pin in this format - **** (for example: 2130)");
    var userinput = Console.ReadLine();
    while (userinput!.Length < 4 || !int.TryParse(userinput, out newPinCode) || newPinCode < 0 || newPinCode > 9999)
    {
        Console.WriteLine("Enter new pin in this format - **** (for example: 2130)");
        userinput = Console.ReadLine();
    }

    Console.WriteLine("Repat new pin");
    var repeatUserInput = Console.ReadLine();
    while (repeatUserInput != userinput)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Pins don't match");
        Console.ResetColor();
        goto firstPinInput;
    }
    pinCode = newPinCode.ToString().PadLeft(4, '0');
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Success, your new pin is {pinCode}");
    Console.ResetColor();



}
void ShowTransactionHistory()
{
    Console.WriteLine("=== Transaction History ===");
    for (int i = transactionHistory.Count - 1; i >= 0; i--)
    {
        Console.WriteLine(transactionHistory[i]);
    }


}

void ShowContactInformation()
{
    Console.WriteLine("=== Contact Information ===");
    Console.WriteLine("Hotline - 2 200 200.");
    Console.WriteLine("Email - info@bank.ge.");
    Console.WriteLine("Number of Branches - 45.");
    Console.WriteLine("Working hours - 09:00 - 18:00");
}


void AddMoneyToBalanceViaGiftCardCode(decimal amount)
{
    decimal amountToAdd = amount;
    balanceInGel = balanceInGel + amountToAdd;

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Money Added - {amountToAdd}.");
    Console.WriteLine($"Total balance - {balanceInGel}");
    Console.ResetColor();

    transactionHistory.Add($"Added - {amountToAdd}GEL via gift card code.");
}

