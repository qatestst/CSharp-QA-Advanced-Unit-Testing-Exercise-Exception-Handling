using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class ExceptionTests
{
    private Exceptions _exceptions = null!;

    [SetUp]
    public void SetUp()
    {
        this._exceptions = new();
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_ValidString_ReturnsReversedString()
    {
        // Arrange
        string input = "hello";
        // Act
        string result = this._exceptions.ArgumentNullReverse(input);
        string expected = "olleh";
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_NullString_ThrowsArgumentNullException()
    {
        // Arrange
        string input = null;
        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentNullReverse(input), Throws.ArgumentNullException);
    }

    [Test]
    public void Test_CalculateDiscount_ValidInput_ReturnsDiscountedPrice()
    {
        //Arrange
        decimal totalPrice = 100.0m;
        decimal discount = 80.0m;
        decimal expected = 100.0m - 100.0m * 80.0m / 100;   //totalPrice - totalPrice * discount / 100;

        //Act
        decimal result = this._exceptions.ArgumentCalculateDiscount(totalPrice, discount);

        //Assert
        Assert.AreEqual(expected, result);

    }

    
    [Test]
    public void Test_CalculateDiscount_NegativeDiscount_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = -80.0m;
        
        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
    }

    
    [Test]
    public void Test_CalculateDiscount_DiscountOver100_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = 110.0m;

        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);

    }

    [Test]
    public void Test_GetElement_ValidIndex_ReturnsElement()
    {
        // Arrange
        int[] array = { 1, 2, 3 , 4, 5};
        int index = 2;
        int expected = 3;
        // Act
        int result = this._exceptions.IndexOutOfRangeGetElement(array, index);

        //Assert
        Assert.AreEqual(expected, result);

    }

    
    [Test]
    public void Test_GetElement_IndexLessThanZero_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 1, 2, 3, 4, 5 };
        int index = -3;
        
        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexEqualToArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = array.Length;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElement_IndexGreaterThanArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = 5;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());

    }

    [Test]
    public void Test_PerformSecureOperation_UserLoggedIn_ReturnsUserLoggedInMessage()
    {
        //Arrange
        bool isLoggedIn = true;
        string expected = "User logged in.";

        //Act
        string result = this._exceptions.InvalidOperationPerformSecureOperation(isLoggedIn);

        //Assert
        Assert.AreEqual(expected, result);

    }

    [Test]
    public void Test_PerformSecureOperation_UserNotLoggedIn_ThrowsInvalidOperationException()
    {
        //Arrange
        bool isLoggedIn = false;
        

        //Act&Assert
        Assert.That(()=> this._exceptions.InvalidOperationPerformSecureOperation(isLoggedIn), Throws.InstanceOf<InvalidOperationException>());
    }

    [Test]
    public void Test_ParseInt_ValidInput_ReturnsParsedInteger()
    {
        //Arrange
        string input = "5";
        //Act
        int expected = 5;
        int result = this._exceptions.FormatExceptionParseInt(input);
        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_ParseInt_InvalidInput_ThrowsFormatException()
    {
        //Arrange
        string input = "string";
        //Act

        //Assert
        Assert.That(()=> this._exceptions.FormatExceptionParseInt(input), Throws.InstanceOf<FormatException>());
    }

    [Test]
    public void Test_FindValueByKey_KeyExistsInDictionary_ReturnsValue()
    {
        //Arrange
        Dictionary<string, int> input = new Dictionary<string, int>();
        input.Add("a", 1);
        string key = "a";
        //Act
        int result = this._exceptions.KeyNotFoundFindValueByKey(input, key);
        int expected = 1;
        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_FindValueByKey_KeyDoesNotExistInDictionary_ThrowsKeyNotFoundException()
    {
        //Arrange
        Dictionary<string, int> input = new Dictionary<string, int>();
        input.Add("a", 1);
        string key = "D";
        //Act & Assert
        Assert.That( ()=> this._exceptions.KeyNotFoundFindValueByKey(input, key), Throws.InstanceOf<KeyNotFoundException>() );
    }

    [Test]
    public void Test_AddNumbers_NoOverflow_ReturnsSum()
    {
        //Arrange
        int a = 5;
        int b = 10;
        int expected = 15;
        //Act
        int result = this._exceptions.OverflowAddNumbers(a, b);

        //Assert
        Assert.AreEqual(expected, result);


    }

    [Test]
    public void Test_AddNumbers_PositiveOverflow_ThrowsOverflowException()
    {
        //Arrange
        int a = int.MaxValue;
        int b = int.MaxValue;

        //Act & Assert
        Assert.That( ()=> this._exceptions.OverflowAddNumbers(a,b), Throws.InstanceOf<OverflowException>());
    }

    [Test]
    public void Test_AddNumbers_NegativeOverflow_ThrowsOverflowException()
    {
        //Arrange
        int a = int.MinValue;
        int b = int.MinValue;

        //Act & Assert
        Assert.That(() => this._exceptions.OverflowAddNumbers(a, b), Throws.InstanceOf<OverflowException>());
        
    }

    [Test]
    public void Test_DivideNumbers_ValidDivision_ReturnsQuotient()
    {
        //Arrange
        int dividend = 100;
        int divisor = 5;
        int expected = 20;
        //Act
        int result = this._exceptions.DivideByZeroDivideNumbers(dividend, divisor);
        //Assert
        Assert.AreEqual(expected, result);

    }

    [Test]
    public void Test_DivideNumbers_DivideByZero_ThrowsDivideByZeroException()
    {
        //Arrange
        int dividend = 100;
        int divisor = 0;

        //Act & Assert
        Assert.That( ()=> this._exceptions.DivideByZeroDivideNumbers(dividend, divisor ), Throws.InstanceOf<DivideByZeroException>());
    }

    [Test]
    public void Test_SumCollectionElements_ValidCollectionAndIndex_ReturnsSum()
    {
        //Arrange
        int[]? collection = { 1, 2, 3, 4, 5, 6, 7, 8, 9,10 };
        int index = 1;
        int expected = 55;
        //Act
        int result = this._exceptions.SumCollectionElements(collection, index);
        //Assert
        Assert.AreEqual(expected, result);


    }

    [Test]
    public void Test_SumCollectionElements_NullCollection_ThrowsArgumentNullException()
    {
        //Arrange
        int[]? collection = null;
        int index = 1;

        //Act && Assert
        Assert.That( ()=> this._exceptions.SumCollectionElements(collection, index), Throws.InstanceOf<ArgumentNullException>()  );
    }

    [Test]
    public void Test_SumCollectionElements_IndexOutOfRange_ThrowsIndexOutOfRangeException()
    {
        //Arrange
        int[]? collection = { 1,2,3,4,5,6,7,8,9,10};
        int index = 10;

        //Act && Assert
        Assert.That(() => this._exceptions.SumCollectionElements(collection, index), Throws.InstanceOf<IndexOutOfRangeException>());

    }

    [Test]
    public void Test_GetElementAsNumber_ValidKey_ReturnsParsedNumber()
    {
        //Arrange
        Dictionary<string, string> dictionary = new Dictionary<string, string>
        {
            { "Ann","1000" },
            { "Boby", "2000"},
            { "Bryan", "3000"}

        };
        string key = "Boby";
        int expected = 2000;
        //Act
        int result = this._exceptions.GetElementAsNumber(dictionary, key);

        //Assert
        Assert.AreEqual(expected, result);

    }

    [Test]
    public void Test_GetElementAsNumber_KeyNotFound_ThrowsKeyNotFoundException()
    {
        //Arrange
        Dictionary<string, string> dictionary = new Dictionary<string, string>
        {
            { "Ann","1000" },
            { "Boby", "2000"},
            { "Bryan", "3000"}
        };
        string key = "Monika";
        
        //Act & Assert
        Assert.That (()=> this._exceptions.GetElementAsNumber(dictionary, key), Throws.InstanceOf<KeyNotFoundException>());
    }

    [Test]
    public void Test_GetElementAsNumber_InvalidFormat_ThrowsFormatException()
    {
        //Arrange
        Dictionary<string, string> dictionary = new Dictionary<string, string>
        {
            { "Ann","NotANumber" }, // ["Ann"] = "NotANumber",
            { "Boby", "2000"},      // ["Boby"] = "2000",
            { "Bryan", "3000"}      // ["Bryan"] = "3000"
        };
        string key = "Ann";

        //Act & Assert
        Assert.That(() => this._exceptions.GetElementAsNumber(dictionary, key), Throws.InstanceOf<FormatException>());

    }
}
