
using Bank;
using NUnit.Framework;
using System.Security.Principal;

namespace BankAccountTests

{
    public class BankAccountTests
    {
      
        [Test]
        public void Test_Bank_Account_With_Positive_Input()
        {
            var myAccount = new BankAccount(1000);
            Assert.That(myAccount.Amount, Is.EqualTo(1000));
        }

        [Test]
        public void Test_Bank_Account_With_Neggative_Input()
        {
            Assert.That(() =>
            {
               new BankAccount(-1000);
            }, Throws.ArgumentException.With.Message.EqualTo("Amount cannot be negative!"));
        }

        [Test]
        public void Test_Bank_Account_With_Zero_Input()
        {
            var myAccount = new BankAccount(0);
            Assert.That(myAccount.Amount, Is.EqualTo(0));
        }

        [Test]
        public void Test_Deposit_Valid_Input()
        {
            var myAccount = new BankAccount(1000);
            myAccount.Deposit(500);
            Assert.That(myAccount.Amount, Is.EqualTo(1500));
        }

        [TestCase(0)]
        [TestCase(-500)]
        public void Test_Deposit_Invalid_Input(int sum)
        {
            Assert.That(() =>
            {
                var myAccount = new BankAccount(1000);
                myAccount.Deposit(sum);
            }, Throws.ArgumentException.With.Message.EqualTo("Deposit cannot be negative or zero!"));
        }
     
        [Test]
        public void Test_Withdrow_Valid_Input()
        {
            var myAccount = new BankAccount(1500);
            myAccount.Withdraw(800);
            Assert.That(myAccount.Amount, Is.EqualTo(684.00));
        }

        [TestCase(0)]
        [TestCase(-800)]
        public void Test_Withdrow_Inavlid_Input(int sum)
        {
            Assert.That(() =>
            {
                var myAccount = new BankAccount(1500);
                myAccount.Withdraw(sum);
            }, Throws.ArgumentException.With.Message.EqualTo("Withdrawal cannot be negative or zero!"));
        }

        [Test]
        public void Test_Withdrow_Equeal_Amount_And_Withdrow()
        {
            Assert.That(() =>
            {
               var myAccount = new BankAccount(1500);
               myAccount.Withdraw(1500);
            }, Throws.ArgumentException.With.Message.EqualTo("Amount cannot be negative!"));
        }


    }
}