# Technical assessment for backend developer

## The purpose of the assessment is to test your ability:
* to deliver a web API to be consumed by external systems
* design a SQL Server database
* integration with other external APIs

## Please use the following tools as part of your solution:
* Database: SQL Server (any version or edition)
* API: MVC, WebApi or NancyFx
* ORM: NHibernate or Entity Framework
* Testing: xUnit or NUnit

If other tools are used, e.g. Windsor IoC container, please document the tools used, but try and stick to the .NET stack.

## What is expected?
The API you will be writing provides information about artists and their releases. The artist information will be stored in a SQL Server database and the release information is provided by the MusicBrainz API.

The API needs to provide the following endpoints:
* ```/artist/search/<search_criteria>/<page_number>/<page_size>``` as a GET. 

  * ```/artist/search/joh``` should return John Coltrane, John Mayer, Johnny Cash, Elton John and John Frusciante
    * The response should contain the following information either in JSON or XML
      * Artist name
      * Originating country
      * Aliases for the artist
      * Link to the artist's albums
    * The return data in JSON format should look as follows (if XML is used, the same structure should be used):
```   
    {
      "results": [
        {
          "name": "John Coltrane",
          "country": "US",
          "alias": [
            "John Coltraine",
            "John William Coltrane"
          ]
        },
        // etc
      ],
      "numberOfSearchResults": 5,
      "page": "1",
      "pageSize": "10",
      "numberOfPages": "1"
  }
```   

The search criteria will be used to search the SQL Server database. The ```page_number``` and ```page_size``` parameters are used for the pagination of the search results. 

The search should return all artist whose name or alias starts with the search criteria. The search should also return pagination information allowing for paging through the search results.

The Excel spreadsheet in the docs folder contains information about 16 artists. The data in the spreasheet needs to be imported into a SQL Server database and used when searching for artists

***Junior developer role***
For the junior developer role, the pagination of the search results does need to be implemented. The implication of this is that all the search results are returned as described above, without any pagination information. The page_number and page_size does not need to be implemented either.
    
* ```/artist/<artist_id>/releases``` as a GET. This endpoint will return all the releases for a selected artist where the artist_id uniquely identifies an artist in the SQL Server database and MusicBrainz API

  * ***This part of the assessment is not applicable for the junior developer role.***
  * ```/artist/6c44e9c22-ef82-4a77-9bcd-af6c958446d6/albums``` will return the first 10 albums from Mumford & Sons.
    * The response should contain the following information either in JSON or XML
      * Release Id
      * Title of release
      * Status release
      * Label which released the release
      * Number of tracks on the release
      * List of artist collabrating on the release
    * The return data in JSON format should look as follows (if XML is used, the same structure should be used):
  ```
      {
        "releases": [
          {
            "releaseId": "9cc88413-d456-4b96-a0c1-09fa6cc2cf88",
            "title": "iTunes Festival: London 2010" ,
            "status": "Official",
            "label": "Gentlemen of the Road",
            "numberOfTracks": "8",
            "otherArtists": [
              {
                "id": "a015074b-e109-412d-9f7b-170b80a0ebbd",
                "name": "Dharohar Project"
              },
              {
                "id": "cd9713d6-6e5f-4143-9412-4d12b7bd47f2",
                "name": "Laura Marling"
              }
            ]     
          },
          //etc
        ]
      }
  ```

## Supporting documentation
Documents can be found in the docs folder of the repository

* An Excel spreadsheet with artist information. This information is used for searching and contains the identifier to link to MusicBrainz.
* Job Specification for the role
* The MusicBrainz API is well documented and the information can be found at http://musicbrainz.org/doc/Development/XML_Web_Service/Version_2/Search

## What should be part of your solution?
* SQL Server scripts to create the database and other database objects required by the solution
* SQL Server scripts to populate the database with artist information (based on the data in the Excel spreadsheet). Basically a number of INSERT statements to populate the database
* Any other documentation needed to execute your solution

## How will the technical assessment be evaluated?
* The database scripts provided will be run against a local SQL Server database (we'll update the connection string to point to the appropriate database)
* The solution will be installed in IIS
* The two endpoints will be invoked, using Postman (https://www.getpostman.com/) to test the results returned. Both positive and negative tests will be executed
* The code will evaluated for clarity, design and readability.
* If any tests are part of the submitted solution, the tests will be run the test the solution. The tests will be evaluated to verify the quality of the tests.

## How do I submit my solution?
Send a pull request from your repository.

## Questions or comments
Please use the issues functionality on Github. All questions will be answered via Github.
