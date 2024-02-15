[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/rwZRQEDp)
## This is an application that allows to view and manage list of products and list of users
## Please, add the next functionality to the application:
### Validation of products:
v 1. **Price**: value should be within boundaries 0 and 100000 V
v 2. **Name**: mandatory field V
v 3. **Description**: 
   - not mandatory field. 
   - if set, length should be longer than 2 symbols V
   - should not be equal to Name but should start with the Name of the product V
 V 4. **Type**: enum with values: *Toy, Technique, Clothes, Transport* - make this field displayed with a SelectList on Views for editing and creation to make impossible entering wrong value.

After clicking on Save button:
 - if there are no validation errors - the product should be saved and displayed in view (details) mode
 - othervise validation errors should be displayed on the same page
 
 ### Binding:
 1. Add an ability to edit all prices at once for products of chosen category:
    - add corresponding links to the view with list of products
    - display **Id, Name and Price** of all products of chosen category on the view for editing prices
    - **price** should be available for editing 
    - **Id** and **Name** - readonly
    - Click on **Save** button: 
      - saves all the prices if there are no validation errors
      - displays errors if there are ones
 v 2. Add an ability to add a new user with query string (and this should be the only way) 
    v - all fields on a creational form should be readonly 
    v - fields should fill in only with parameters from query string
    v - on click on the Save button user should be displayed in view mode
 
