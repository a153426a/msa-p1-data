# msa-p1-data
# URL 
http://msa-p1-2020-loki-data.azurewebsites.net/

# Database: 

Address Table: 

Students and addresses are in one to many relation. 
In the address table, street number and street is not required since they are a bit too private to be recorded(assuming this table is not for direct mailing service). 
Also, all the attributes are set to have a maximum length so that the databased is not filled with dirty data. 

![image](https://user-images.githubusercontent.com/3874712/88129244-b4f77e00-cc2b-11ea-823a-603a7291ce18.png)

Student Table: 

![image](https://user-images.githubusercontent.com/3874712/88129296-d6f10080-cc2b-11ea-848f-6de65b4ffc64.png)

# API 
![image](https://user-images.githubusercontent.com/3874712/88129909-5cc17b80-cc2d-11ea-8d3a-cead83ecbf2a.png)

Students APIs can still achieve the original functions. 

Address APIs brief explaination are listed below. 

GET /api/Addresses: Gets all the addresses 

POST /api/Addresses: Create an new address, if the student id in address does not exist in the student table, return not found. 

GET /api/Addresses/{id}: Gets the address with specified addressID. I created addressID as primary key to identify each and single address.If addressId does not exist, return not found.  

PUT /api/Addresses/{id}: Edit an address by addressId. If addressId does not exist, return not found. The only changable attribute are "streetNumber, street, suburb, city, postcode, country". Once address is created, studentId attached to it can not be changed, to pervent potential problems. 

DELETE /api/Addresses/{id}: Delete an address by addressId. If addressId does not exits, return not found. 

PUT /api/Addresses/ChangeByStudentId: User need to provide studentId, addressId and an address for using this API. If studentId does not exist, return not found. If studentId does not equal to "studentID" attribute from the addressId, return bad request. 

POST /api/Addresses/AddByStudentId: User need to provide studentId and an address for using this API. If studentId does not equal to "studentID" attribute from the address, return bad request.
