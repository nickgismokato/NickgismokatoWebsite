# OAuth2

`OAuth2` is the authentication service which WarcraftLogs is utilizing. A client has to be made at [WarcraftLogs API](https://www.warcraftlogs.com/api/docsm). The link is a link to the documentation on how to do it.

## How it works



## What a client is needed to do

A client that want to utilize either Warcraftlogs own API or the ReunionLog service, will need to create a client at [WarcraftLogs Client](https://www.warcraftlogs.com/api/clients/). This requires to a user at their website. From here you will have to do the following:

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