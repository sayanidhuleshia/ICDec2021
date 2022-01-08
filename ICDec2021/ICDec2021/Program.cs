using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

// See https://aka.ms/new-console-template for more information

//open chrome browser
IWebDriver driver = new ChromeDriver();
driver.Manage().Window.Maximize();

//launch turnup portal
driver.Navigate().GoToUrl("http://horse.industryconnect.io/");

//identify username textbox and enter valid username
IWebElement userNameTextbox = driver.FindElement(By.Id("UserName"));
userNameTextbox.SendKeys("hari");

//identify password textbox and enter valid password
IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
passwordTextbox.SendKeys("123123");

//click on login button
IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
loginButton.Click();

//check if user is logged in successfully
IWebElement helloHari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
if (helloHari.Text == "Hello hari!")
{
    Console.WriteLine("Logged in successfully, test passed");
}
else
{
    Console.WriteLine("Login failed, test failed");
}



//create time and material record

//go to TM page
IWebElement administrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
administrationDropdown.Click();
IWebElement tmOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
tmOption.Click();

//click on create new button
IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
createNewButton.Click();


//Select material from typecode dropdown
IWebElement typeCodeDropDown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
typeCodeDropDown.Click();

IWebElement materialOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
materialOption.Click();

//Identify the code textbox and input a code
IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
codeTextbox.SendKeys("Decemer2021");

//Identify the description textbox and input a description
IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
descriptionTextbox.SendKeys("Decemer2021");

//Identify the price textbox and input a price
IWebElement priceTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
priceTag.Click();

IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
priceTextbox.SendKeys("12");

//Click on save button
IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
saveButton.Click();
Thread.Sleep(2000);

//click on go to last page button
IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
lastPageButton.Click();
Thread.Sleep(2000);

//assertions: check if record created is present in the table and has expected value
IWebElement actualCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
if (actualCode.Text == "Decemer2021")
{
    Console.WriteLine("Material record created successfully. Test has passed");
}
else
{
    Console.WriteLine("Record not found. Test failed");
}