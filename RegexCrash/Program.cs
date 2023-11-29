using System.Text.RegularExpressions;

#region RegexCrash1

const string value = "RemainderPayment";

#endregion RegexCrash1

#region RegexCrash2

// const string value = "RemainderPaymentMoneyLaunderingCommittee";

#endregion RegexCrash2

#region RegexCrash3

//const string value = "RemainderPaymentMoneyLaunderingCommitteeNotPaid.deb";

#endregion RegexCrash3

#region RegexCrash4

// const string value = "RemainderPaymentMoneyLaunderingCommitteeNotPaid";

#endregion RegexCrash4

const string pattern = @"^(?:\w+\\?)*$";
var regex = new Regex(pattern, RegexOptions.None, TimeSpan.FromSeconds(1));
var result = regex.IsMatch(value);
Console.WriteLine(result);