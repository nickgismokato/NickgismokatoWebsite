# ReunionLog

## Summary

# OAuth2

`OAuth2` is the authentication service which WarcraftLogs is utilizing. A client has to be made at [WarcraftLogs API](https://www.warcraftlogs.com/api/docsm). The link is a link to the documentation on how to do it.

Then when you want to send data to or receive data from WarcraftLogs, a service will have to do the following:

1. Ask the OAuth service for a token with given `client_id` and `client_secret`.
2. Receive the `Token` for further use which all data requests need to have in their `GET` requests.
3. Request data with the `GraphQL` query.

Essentially when you have requested a `Token` the following is what to do next:

```bash
curl --header "Authorization: Bearer <access_token>" <GRAPHQL API URL>
```

Essentially you header of your `curl` is the `Token` and the body is the API url with the query.

# GraphQL Query