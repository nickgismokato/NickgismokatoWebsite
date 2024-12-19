# OAuth2

`OAuth2` is the authentication service which WarcraftLogs is utilizing. A client has to be made at [WarcraftLogs API](https://www.warcraftlogs.com/api/docsm). The link is a link to the documentation on how to do it.

## How it works



## What a client is needed to do

A client that want to utilize either WarcraftLogs own API or the ReunionLog service, will need to create a client at [WarcraftLogs Client](https://www.warcraftlogs.com/api/clients/). This requires to a user at their website. From here you will have to do the following:

1. Follow the link above (*WarcraftLogs Client*).
2. Enter a client name. The client name is used to identify the client in the list view. Client names will be visible to your site users when authorizing them.
3. Enter any redirect URIs needed. If you need to support multiple redirects you can separate the URLs with commas. Make sure you escape commas within a single URI.
4. Click Create. 

To utilize the ReunionLog service a `data.json` file will have to be created. You will then need to put your `client_id` and `client_secret` inside this file on the following form:

```json
{
	client_id:"<client_id>"
	client_secret:"<client_secret>"
}
```
For example if you id is 0001 and your secret is WarcraftIsLove then it should look like this:

```json
{
	client_id:"0001"
	client_secret:"WarcraftIsLove"
}
```

This is the only setup required from you, the user. You will have to provide your own `GraphQL` queries and variables but this should come at no surprise. If you want to know more about how to make your own queries and where you can find the schema for WarcraftLogs, go read [my documentation](../GQL/Overview.md)


## How is the data stored

The data we "*store*" is that of a `client_credentials.json` file and a `Token` class. When I say **we** I mean you. Everything is handled as a `LocalStorage` which means the server will only get the data it needs and then after remove it. 

Essentially you will be holding all the data on your local machine. You can read more about it [here](https://github.com/Blazored/LocalStorage)

### `client_credentials.json`

This file will contain the now correctly formatted data of your `.json` file you upload to the server. This file will be stored indefinitely until you either manual remove it or you remove it via our tool on the website. **NEED TO IMPLEMENT**

This data will only be handled via `Nickgismokato.Client.Components.ReunionApp.http`. This is the client side of the website. If you want to read more about it, you can read it [here](../../Website/server_client.md). The simple version is that Blazorise is running all the `.client` parts on the end-user and not on the server. Therefore anything you do with the majority of this website, will be ran on your computer with minimal data coming to the server-side.

### `Token`

As with `client_credentials.json`, the `Token` which we use to authenticate our queries, will only be held in a `class Token` inside the client side of the website. No physical data will be stored on either the server side or the client side. Again, this is handled within the code so no data will be accessible.

That being said, I will note that we send the `Token` in the header every time we have to make a query. So if the `Token` is being stored on WarcraftLogs website, we have nothing to do with it and refuse any responsibility for any wrong outcomes from this action. 

