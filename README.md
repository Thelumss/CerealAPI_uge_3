# CerealAPI

# 

# API END PONITS

# Cereal Controllor

# /api/CerealControllor

# Need no input gives back a json with all of the cereal produckts

# /CerealbyId{CerealId}

# Needs to be given a id of a cereal gives back a json object contatining the cereal

# /sugar{sugar}

# Needs to be given a sugar value gives back a json object containing all the cereal with that amount of sugar

# 

# /brand{brand}

# Needs to be given a brand name gives back a json object containing all the cereal with that brand name

# /post

# Needs to be given a cereal in json

# If a cereal with that id exist is information is overridden

# If the cereal is given a id that does not exist it gives error and does noting more

# If  no id is given it defaults to 0 and treats it as nonexistent and adds the cereal to the database that gives it is id

# /delete{CerealId}

# Need to be given a id delets a cereal with that id

# UserControllor

# /api/UserControllor

# Need no input gives back a json with all of the users in the database

# 

# Setup

# In appsettings.json you need to give it a connection string for your database you only need to setup the database not the tables.

# You can use the migrations to create the tables and then when you run the program it populates the database if the tables with information.

# 

# 

