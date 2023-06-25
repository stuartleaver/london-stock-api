# London Stock API

## System Design
### API
The API is designed around a single Function App that contains endpoints to retrieve transactions and requests for stock prices as follows:

| Endpoint                  | Verb | Description                                                     |
| -----------               | -----| -----------                                                     |
| /transaction              | POST | Recieves stock transactions                                     |
| /stockprice               | GET  | Returns the stock price for all stocks in the transaction table |
| /stockprice/{stockSymbol} | GET  | Returns the stock price for a single stock                      |
| /stockprice               | POST | Returns the stock price for a list of stocks                    |

The choice of a Function App was down to this being an MVP. The benefit of a Function App is that it allows a solution to be up and running very quickly. Function Apps in Azure also allow scaling based on demand and can be run quite cheaply. The same could have been achieved in a Web API and hosted in an App Service, but scaling and cost may not lend themselves to an MVP.

The `transaction` and `stockprice` endpoints have been placed in different classes. This would allow them to be split into different Function Apps if needed. If there is different demand between them, this will allow scalability independent of each other.

### Data Model
The API uses a simple data model as follows. The data types are suggestions based on if an actual database was being used. 

![DB Schema](images/schema.png)

There are some differences to what this would be in a real relational database such as MS SQL Server. These are:
* In the Transaction table, there would be a primary key along with the date and time of the transaction
* The Broker table would contain more details for the Broker

### Data Structure
The database is mimicked through static classes and Lists. Each time the API is run, the data obviously won't be persisted. Should this be deployed to Azure, then a real database would be used.

### Data Validation
Some sample validation is included for transactions. This would be changed or added to if more specific validation was needed.

In the Stock and Broker tables, a list is sample stock symbols and broker Ids are given so that example validation could be used within this example. While an assumption could be made that the application calling the API would allow only valid stock symbols and broker Id's, the decision was made to still validate them.

### Endpoint Details
#### /transaction
URL (localhost)

`http://localhost:7115/api/transaction`

Example request body

```json
{
    "stockSymbol": "VOD",
    "stockPrice": 15,
    "numberOfShares": 2,
    "brokerId": 1
}
```

Example response

`
Transaction received
`

#### /stockprice - GET
URL (localhost)

`http://localhost:7115/api/stockprice`

Example response

```json
[
    {
        "stockSymbol": "VOD",
        "stockPrice": 15.0
    },
    {
        "stockSymbol": "RMV",
        "stockPrice": 15.0
    }
]
```

#### /stockprice/{stockSymbol} - GET
URL (localhost)

`http://localhost:7115/api/stockprice/{stockSymbol}`

Example response

```json
{
    "stockSymbol": "VOD",
    "stockPrice": 15.0
}
```

#### /stockprice - POST
URL (localhost)

`http://localhost:7115/api/stockprice`

Example request body

```json
[
    "VOD",
    "RMV"
]
```

Example response

```json
[
    {
        "stockSymbol": "VOD",
        "stockPrice": 15.0
    },
    {
        "stockSymbol": "RMV",
        "stockPrice": 15.0
    }
]
```

### Logging
Logging has been included so that issues can hopefully be found quicker if needed.

There is a sample Postman collection in the `postman` folder.

## Enhancements
### Scalability
The system is scalable in terms of the Function App should demand increase. However, there are a few issues with the use of just the `Transaction` table:
* The table is used for both read and writes. Demand could therefore cause contention and race conditions:
    * Reads and writes could cause locking and performance issues
    * At the moment, the stock price is the average across all transactions for that stock. Depending on timing, the stock price given could be out of date.
* The table could grow in size.

Suggest solutions to these issues is:
* Create a second table that stores the price of each stock which could be updated via another process when transactions are made. The level of concurrency control would help decide what that process is. This would then separate reads from writes.
* Table partitioning or sharding (although I have never used sharding) could be used to solve the table size issue.

The current design makes database calls the database for each transaction to check if the stock symbol and broker Id are valid. Although this may be quite quick in isolation, it will add up with a large number of transactions and potentially affect the database performance as well. This could be solved by holding those two lists in cache, as that will be quicker than hitting the database each time. If either of those lists needs to change, then the corresponding record in the cache can be invalidated and re-loaded or added.

As mentioned above, only one Function App is used. This could be separated into two so that they can scale independently.