# SQLToolBox

SQLToolBox is a tool created in C# in order to:

1. Create CRUD (Create, Read, Update, Delete) SQLServer Stored Procedures. 
2. C# Entities.  
3. C# generates SQLCommand for CRUD with sql statements.

## Prerequisites
1. Visual Studio >= 2015
2. Framework 4.0
3. SqlServer 200X.

If you want to executing just click on appSQLToolBox.exe


## Running SQLToolBox

1. Connect to SQL Server<BR>
![1](https://user-images.githubusercontent.com/43474323/64068442-5da48580-cbf5-11e9-86fa-afcc998273f2.JPG)

2. In order to create all Entities, right click on Database then "Crear Entities" <BR>
![2](https://user-images.githubusercontent.com/43474323/64068545-c50f0500-cbf6-11e9-939b-77c5f7e1e728.JPG)

3. All Entities area created within right textbox 
![3](https://user-images.githubusercontent.com/43474323/64068552-dce68900-cbf6-11e9-9cc3-e389970a1f16.JPG)

4. Create CRUD Stored Procedures. You MUST select each table<BR>. If table doesn't have Primary Key Delete, Update and Read can't be created. You will notice a "message". After create the CRUD click on SQL Ejecutar Button.
![4](https://user-images.githubusercontent.com/43474323/64068555-ee2f9580-cbf6-11e9-8f94-ae1e5790a70d.JPG)

5. Generate SqlCommands CRUD that it will be usefull for Sql embedded  sentences. Notice that it map SqlRow to Object  
![5](https://user-images.githubusercontent.com/43474323/64068560-03a4bf80-cbf7-11e9-97f1-e5605d97e1e5.JPG )


## License
Feel free to improve it!
https://github.com/lateraluz/SQLToolBox/blob/master/LICENSE
<BR>
  <BR>
**knowledge belongs to humanity**, *Pascal*

