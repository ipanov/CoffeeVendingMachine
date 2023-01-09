## Please describe which technologies you would use if you are building a real-life application.

Obviosly it is going to require a more sofisticated UI.

Assuming it is running on an actual device connected to the internet 24/7 the UI either be a mobile app or more unlikely a web application hosted on the cloud.

The first option is certainly preferable since the device should be able to operate offline (though this can be also achieved with a web SPA to a certain extent).

React Native is a great compromise, the performance and complexity required for a simple UI does not mandate a fully native approach and dedicated mobile developer.

Backend will be integrated with a payment processor, also some integration with device monitoring services and managing the stock of cofeee and coins for cash payments with suppliers would be neccesary.

An event based approach with a service bus would be best for this purpose. The events triggered by the machine (low stock, scheduled service, unsheduled failiures, overfilled coins) can be consumed by an iot hub or service bus hosted on the cloud behind an endpoint with an api gateway.

For payment and third party resources (pictures of coffees, recipies for preparing coffees from beans etc) as well as price updates and similar, traditional payment processors, restfull api's and polling for files on certain network locations can be used.
 
A NoSQl database might also be usedull on the machine to persist some data in case of offline operations.


## Describe which cloud services you would have been using in the case of a real-life application.

The application logic lends itself well to being migrated for hosting on managed cloud services.

Most actions and operations are atomic and stateless in nature so the stack of choice might be


- Azure Application Gateway - for the API

- Azure IoT Hub for sending events ( not really faimiliar but should be a god fit)

- Azure Functions

- Azure Cosmos DB

- Azure SQL

- Amazon S3 (Not sure what is the equivalent on Azure)

Apart from these, Analytics can be of great help for a network of such devices (like in the 1000's), so that we can monitor some trends (like sales trends and marketting on the coffee machine), also AI services can do a great job to predict and optimize like for example replenihsment of these machines in an  givenarea.