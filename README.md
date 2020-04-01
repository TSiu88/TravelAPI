# _[Travel API](https://github.com/TSiu88/TravelApi)_

#### _Brief desc of Project, 03.30.2020 - 04.01.2020_

#### By _**Tiffany Siu, Jiwon Han, and Adela Darmansyah**_

<!-- [![Project Status: Inactive – The project has reached a stable, usable state but is no longer being actively developed; support/maintenance will be provided as time allows.](https://www.repostatus.org/badges/latest/inactive.svg)](https://www.repostatus.org/#inactive) -->
<!-- [![Project Status: Active – The project has reached a stable, usable state and is being actively developed.](https://www.repostatus.org/badges/latest/active.svg)](https://www.repostatus.org/#active) -->
[![Project Status: WIP – Initial development is in progress, but there has not yet been a stable, usable release suitable for the public.](https://www.repostatus.org/badges/latest/wip.svg)](https://www.repostatus.org/#wip)
![LastCommit](https://img.shields.io/github/last-commit/tsiu88/TravelAPI)
![Languages](https://img.shields.io/github/languages/top/tsiu88/TravelAPI)
[![MIT license](https://img.shields.io/badge/License-MIT-orange.svg)](https://lbesson.mit-license.org/)

---
## Table of Contents
1. [Description](#description)
2. [Setup/Installation Requirements](#setup/installation-requirements)
    - [Requirements to Run](#requirements-to-run)
    - [Instructions](#instructions)
    - [Other Technologies Used](#other-technologies-used)
3. [Notable Features](#notable-features)
4. [Specifications](#specifications)
5. [User Stories](#user-stories)
6. [Screenshots](#screenshots)
7. [Test Case Example](#test-case-example)
8. [Known Bugs](#known-bugs)
9. [Support and Contact Details](#support-and-contact-details)
10. [License](#license)
---
## Description

#### 3/31/20 Work at Home Summary
- Travel API
- Struggles:
  - return type for api calls
  - GET for popular by number of reviews
  - get average of ratings and show
  - calculate average of ratings when creating reviews

#### 3/30/20 Work at Home Summary
- CretaceousPark Example
- Console API Call Example
- MVC API Call Example
- Travel API
- Struggles:
  - objects null inside query, due to lazy loading proxies?
  - virtual objects inside models
  - seed data not appearing
  - lazy loading proxies and entity framework version conflicts

_README under construction_
<!-- _Detailed desc w/ purpose/usage, what does, motivation to create, why exists, other info for users/developers to have_ -->

## Setup/Installation Requirements

_This program requires .NET Core SDK to run. [Here is a free tutorial](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-c-and-net) for installing .NET on Mac or Windows 10 from the [official website](https://dotnet.microsoft.com/download/dotnet-core/)._ 

_This program also makes use of SQL databases. We recommend using MySQL Workbench to build your databases. [Here is a free tutorial](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql) for installing MySQL WorkBench and MySQL Community Server on Mac (using links [Mac1](https://dev.mysql.com/downloads/file/?id=484914) and [Mac2](https://dev.mysql.com/downloads/file/?id=484391)) or [Windows 10](https://dev.mysql.com/downloads/file/?id=484919)._

### Requirements to Run
* _.NET Core_
* _ASP.NET Core MVC_
* _MySQL Workbench_
* _MySQL Community Server_
* _Entity Framework_
* _Command Prompt_
* _Web Browser_

### Instructions

*This application may be viewed by:*

1. Download and install .NET Core from the [official website](https://dotnet.microsoft.com/download/dotnet-core/)
2. Download and install MySQL Workbench and Community Server for Mac or Windows by following the instructions [here](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql).
3. Click clone the [repository](https://github.com/TSiu88/TravelAPI.git) from my [GitHub page](https://github.com/TSiu88) to copy the repository link
4. Use a command line interface to type `git clone (repository-link-here)` to copy the project into the current folder and then move into the repository's directory that was just created with `cd (project-name-here)`
5. Start up a local server by opening MySQL Workbench and adding a `MySQL Connections` using the default IP address and Port (IP 127.0.0.1, Port 3306), username (root), and password from setup.
6. Run `dotnet restore` and `dotnet build` in command line interface of the repository's main project directory
7. Run `dotnet run` to start up the program in the command line interface
8. Type the URL listed under "Now listening on:" into a web browser to run

## Other Technologies Used
* _C#_
* _HTML_
* _CSS_
* _MSTest_
* _Razor_
* _Markdown_

## Notable Features
<!-- _features that make project stand out_ -->

## Specifications

<!-- * _List of features the program should do, from simplest to more complex, handling all possible cases.  Can do as text or put in table, with example input and output_
  * _Example Input: expected input_
  * _Example Output: expected output_
-->

<!-- <details>
  <summary>Click to expand to view specifications</summary>

| Specification | Input | Output |
| :-------------     | :------------- | :------------- |
| The program displays welcome message and menu with prices | Application start | Welcome message and menu displayed |
| The program displays special deals in readable format | Application start | Special deals displayed ("Buy 2, get 1 free" "3 for $5") |
| The program takes input of user that is not an integer, then assume 0 ordered | Bread="aaa", Pastry="" | Bread=0, Pastry=0 |
| The program takes number of loaves of bread and pastries and displays totals | Bread=4, Pastry=4 | Bread=$20, Pastry=$8, Total=$28 |
| If input qualifies for special deals, costs calculated using discounted price | Bread=3, Pastry=3 | Bread=$10, Pastry=$5, Total=$15 |

</details> -->

## User Stories

- [x] As a user, I want to GET and POST reviews about travel destinations.
- [x] As a user, I want to GET reviews by country or city.
- [x] As a user, I want to see the most popular travel destinations by number of reviews or by overall rating.
- [x] As a user, I want to PUT and DELETE reviews, but only if I wrote them. (Start by requiring a user_name param to match the user_name of the author on the message. You can always try authentication later.)
- [x] As a user, I want to look up random destinations just for fun.


## Screenshots

<!-- _Here is a snippet of what the input looks like:_

![Snippet of input fields](img/snippet1.png)

_Here is a preview of what the output looks like:_

![Snippet of output box](img/snippet2.png) -->

<!-- _{Show pictures using ![alt text](image.jpg), show what library does as concisely as possible but don't need to explain how project solves problem from `code`_ -->

## Known Bugs

_There are currently no known bugs in this program_

## Support and contact details

_If there are any question or concerns please contact us at our emails: [Tiffany Siu](mailto:tsiu88@gmail.com), [Jiwon Han](mailto:jiwon1.han@gmail.com), and [Adela Darmansyah](mailto:adela.yohana@gmail.com). Thank you._

### License

*This software is licensed under the MIT license*

Copyright (c) 2020 **_Tiffany Siu, Jiwon Han, Adela Darmansyah_**
