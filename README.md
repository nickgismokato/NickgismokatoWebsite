# Nickgismokato.com
## Summary
### This Project
<p align="center">
	<a href="./VERSION">
		<img src="https://img.shields.io/badge/Version-0.2.0-informational"/>
	</a>
	<a href="#">
		<img src="https://img.shields.io/badge/Last_Updated-10/12/24-informational"/>
	</a>
</p>
<p align="center">
	<a href="./LICENSE">
		<img src="https://img.shields.io/github/license/Ileriayo/markdown-badges?style=for-the-badge"/>
	</a>
</p>

___

**A simple website to contain most of my web services and applications.**

---

### Backend
<!--https://github.com/tandpfun/skill-icons?tab=readme-ov-file-->
<p align="center">
	<a href="nickgismokato.com">
		<img src="https://skillicons.dev/icons?i=cs,html,css,cs,dotnet&perline=5"/>
	</a>
</p>


<!--https://github.com/progfay/shields-with-icon-->
![C#](https://img.shields.io/badge/12-239120?style=for-the-badge&logo=csharp&logoColor=white&label=C%23)
![.NET](https://img.shields.io/static/v1?style=for-the-badge&message=8.0&color=512BD4&logo=.NET&logoColor=FFFFFF&label=.NET)
![Linux](https://img.shields.io/static/v1?style=for-the-badge&message=Linux%20Development&color=222222&logo=Linux&logoColor=FCC624&label=)


### Dependencies
<p align="center">
	<a href="nickgismokato.com">
		<img src="https://skillicons.dev/icons?i=graphql,bootstrap&perline=5"/>
	</a>
</p>

![GraphQL](https://img.shields.io/static/v1?style=for-the-badge&message=GraphQL&color=E10098&logo=GraphQL&logoColor=FFFFFF&label=)
![Bootstrap](https://img.shields.io/static/v1?style=for-the-badge&message=V5&color=7952B3&logo=Bootstrap&logoColor=FFFFFF&label=Bootstrap)

---

## About

This is the repository for [Nickgismokato.com](https://nickgismokato.com). This repo will **only** contain the source code for the website. All data the website will contain will not be put onto the repo. Furthermore the `oauth` credentials and the tokens will also not be uploaded to the repo.

### About the website

This website is a product created out of four needs:

1. Learning [Blazorise](https://blazorise.com/) for `.Net8.0` with `Bootstrap5`.
2. Creating a website which contain my achievements and my qualifications.
3. Creating a webservice for the guild `New Reunion` to help them simplify their logging experience with [Warcraftlogs](https://warcraftlogs.com) such that their excel work get simplified. A general `GraphQL` query can be created for anyone just looking for some specific data.
4. A place where I can contain my documentations for [SaTyR](https://www.satyr.dk/)

Furthermore this website will contain some of my own webservices. 

- :zap: Test

## Development Status and Progress

The development is solo project, so this may or may not take some time to implement planned features and also maintain the website.

**Development Plan:**
- [ ] Website
  - [ ] Implement User Sessions
    - [ ] Use https://github.com/Blazored/SessionStorage
  - [ ] Implement Web Paginator
    - [ ] Either use custom extension or build the `.css` itself
    - [ ] Implement this is `ReunionLog` and `WarframeApp`
  - [ ] Implement `RichText` for global show 
- [ ] ReunionLog
  - [ ] Handle `credentials.json` file
    - [ ] File restrictive
    - [ ] `Type` checking
    - [ ] `Name` checking
  - [ ] Authenticate with `Oauth` at [WarcraftLogs](https://warcraftlogs.com)
    - [ ] Create `.credentials` as a temporary file for longer sessions
    - [ ] Error handling
  - [ ] Query with GraphQL
    - [ ] Create `ReunionLog` settings
    - [ ] Handle custom query
      - [ ] Custom file `.query`
      - [ ] As pure text
  - [ ] Show return query string
    - [ ] default `.json`
    - [ ] For `ReunionLog` show also `Google Excel` for copy-paste
    - [ ] Store temporary data for each user in `/data/reunionlog/<user>/`
  - [ ] Download return query string as `.json`
    - [ ] Implement button
    - [ ] Implement copy-to-clipboard button
  - [ ] Document everything
- [ ] WarframeApp
  - [x] Implement a `HTTP` query handler
    - [x] download as `.json` in `/data/warframe/`
  - [ ] Implement general objects for each `.json` type for easier handling
    - [ ] `Arcanes`
    - [ ] `Conclave`
    - [ ] `Events`
    - [ ] `Factions`
    - [ ] `FissureModifiers`
    - [ ] `Items`
    - [ ] `Languages`
    - [ ] `Locales`
    - [ ] `MissionTypes`
    - [ ] `Mods`
    - [ ] `OperationTypes`
    - [ ] `PersistentEnemy`
    - [ ] `SolNodes`
    - [ ] `Sortie`
    - [ ] `Syndicates`
    - [ ] `Tutorials`
    - [ ] `UpgradeTypes`
    - [ ] `Warframes`
    - [ ] `Weapons`
  - [ ] Create a list form to view the data of the objects
    - [ ] Implement a handler to handle `EventCalls` for screen
    - [ ] Implement a custom sorter for each type
  - [ ] Create an automatic updater which update every `.json`
    - [ ] Implement a handler in case a `.json` file could not be requested
    - [ ] Implement a reporter for the last time the documents have been updated.
  - [ ] (*Optional*) Implement a version controller for `Warframe` updates
  - [ ] Document everything
- [ ] SaTyR Documentation
  - [ ] Implement a way for admin to store data on-the-go without needing a recompile
    - [ ] Implement a version control for this
    - [ ] Implement a handler incase there where problems with the upload
  - [ ] Implement a list for all stored documents
    - [ ] Implement a handler for all stored documents
    - [ ] (*Optional*) Implement Tags for the documents
  - [ ] Implement a `.pdf` preview of the document
    - [ ] Implement this as an "*in-page*" handler
  - [ ] Implement `html` files as a alternative to `.pdf` files
    - [ ] **Important** These will not be automated


## Prerequisites 

Make sure to have `.NET8.0 SDK` installed. Everything else will be handles by `.NET`. 

### Windows and linux:

Go to this [link](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) and download the `SDK 8.x.y` version for your OS.

### GNU+Linux:
Go to this [link](https://learn.microsoft.com/da-dk/dotnet/core/install/linux?WT.mc_id=dotnet-35129-website) and follow the instructions. The official distributions that supports `.NET` can be found here: https://packages.microsoft.com/

## Usage

### Sever Running

**Summary:** To run this website on a server first clone this repository and then run the project inside `Nickgismokato` and **not** the `Nickgismokato.Client`.

**Steps:**

1. Navigate to a directory where you, the user, have permission.
2. Clone the repository `git clone https://github.com/nickgismokato/NickgismokatoWebsite.git`
3. Navigate to `Nickgismokato/`
4. Use the .NET run command: `dotnet run`

**Optional steps**
- (*Optional*) Make sure `/var/log/website/` has writing permissions since this is where our log files will be stored by our program

## License
<p align="center">
	<a href="./LICENSE">
		<img src="https://img.shields.io/github/license/Ileriayo/markdown-badges?style=for-the-badge"/>
	</a>
</p>

We are using [MIT](./LICENSE) License. It is up to other developers to read and understand this license.