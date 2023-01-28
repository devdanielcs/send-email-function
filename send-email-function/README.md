# About
This application was developed using .NET 6 and Azure Functions version 4.

This Azure function has been specifically crafted to enable the efficient and reliable transmission of emails through the use of the SMTP protocol.

In order to utilize this application, it is necessary to set up your email credentials and SMTP settings within the appsettings file or during the release deployment of the project.

<br/>

# Request and Fields

Below, we have examples of requests and responses, as well as a description of the fields that must be submitted.

| PROPERTY | DESCRIPTION | TYPE | REQUIRED? |
| -------- | ----------- | ---- | --------- |
| Recipient | Email of the person who will receive the email | String | Yes |
| CCs | List of emails that will receive a copy of the email | List string | No |
| Subject | Title of the email that will be sent | String | Yes |
| Message | Message that will be sent in the body of the email | String | Yes |
| IsImportant | Marks the email as an important message | Boolean | No |

<br/>

**REQUEST EXAMPLE**
```
--request POST ".../api/email/send"
--header "Content-Type: application/json"
--body
{
    "Recipient": "email@test.com",
    "CCs": [
        "email_cc1@test.com",
        "email_cc2@test.com"
    ],
    "Subject": "Email sending test",
    "Message": "This is the content of the email message that will be dispatched.",
    "IsImportant": true
}
```
<br/>

**RESPONSE EXAMPLES**

```
Example of response upon successful email transmission
--status code 200 Ok
```

```
Example of response when a field is incorrect
--status code 400 Bad Request

[
    {
        "field": "Recipient",
        "error": "Recipient is in an invalid format"
    },
    {
        "field": "Subject",
        "error": "Subject must not be empty"
    },
    {
        "field": "Subject",
        "error": "Subject must not be null"
    }
]
```


```
Example of response when an internal error occurs in the application
--status code 500 Internal Server Error
```