# SShepherdDonation

The IDE is: Visual Studio Professional 2013.

Issues found:
When I used the ajax to render the Secure fileds partial view returned by controller:
1, click the process button for first time, it works well.
2, click the process button for more than second time, it behaveves strange.
The ammount is added to the account, but the returned response from eWay sandbox includes the validation errors.
I am thinking I have not find a way to use the secure fileds with the ajax.
So I have to refresh the page when user clicks the process button rather than ajax refresh the secur fileds form.

