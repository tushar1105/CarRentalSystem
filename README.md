# READ-ME: Tushar Sharma's Car Rentals - A Webapp by Tushar Sharma

## Application Overview

    - The website allows customers to view necessary information about all available cars for rent on the homepage.

    - The customers can then reserve a car by filling out some basic details and choose a reservation date and time according to their convenience.

    - On successfull reservation, the summary of the transaction is displayed to the customer.

    - Once a car has been reserved, it is no longer available for reservation to other customers and the status of the car is changed to "Reserved" on the homepage.

    - Each car diplays the number of times it has been reserved in the past.

    - A login section is provided, on successfull login the admin can view all reservations made at once.

    - JSON files are used to read and write data (Cars, Reservations and Users) which act as a persistent storage for the application.

    - Server side validations have been implemented for the necessary fields to ensure that the data entered by the customer is consistent.

    - For greater code readability, the code files contain descriptive comments for the functionality of each module.

## Application Structure

    # Models
    - Car.cs: model class to store a new car as an object with related attributes.
    - Reservation.cs: model class to store a new reservation as an object with related attributes.
    - CarJSONRepository.cs: model class to store and retrieve all cars into a JSON file (cars.json).
    - FinalReservationData.cs: model class to store the Car and Reservation data as objects.
    - FinalReservationJSONRepository.cs: model class to store and retrieve all reservation data into a JSON file (reservations.json).
    - UserJSONRepository.cs: model class to store and retrieve all users into a JSON file (users.json).
    
    # Controllers/Domain files
    - Index.cshtml.cs: control file for the index page(homepage).
    - Reservation.cshtml.cs: control file for the new reservation page.
    - Success.cshtml.cs: control file for the success page.
    - Login.cshtml.cs: control file for the login page.
    - AllReservations.cshtml.cs: control file for the AllReservations page.
    - Error.cshtml.cs: control file for the Error page.

    # Views
    - Index.cshtml: index page/hoempage.
    - Reservation.cshtml: the reservation page.
    - Success.cshtml: the success page.
    - Login.cshtml: the user login page.
    - AllReservations.cshtml: the page that lists all reservations.
    - Error.cshtml: the error page for invalid credentials.
