Connect to your own database first at appsettings.json and do migrations -> then come back to the readme

To access hotchocolate start the application where you get a https://localhost:0000/swagger/index.html as auto start.

Change the URL to https://localhost:0000/GraphQL and then you'll access it.

Once here you go to Operation and write the query so it can access your backend query in Server.

Query that you would write in the URL once you've accessed graphql looks like this:

To fetch one single user where userId here is the parameter you send in. Its a guid in this instance

query variableName1 {
userScope {
user (userId: "604023CB-DEBE-41BC-BC7C-6A6EF46C865F") {
id
userName
lastName
firstName
}
}
}

To fetch multiple you need to change the query from "user" to "users". It could look like this. Dont have this implemented yet, but a good try to achieve fetching of multiple users

query variableName2 {
userScope {
users{
id
userName
lastName
firstName
}
}
}
