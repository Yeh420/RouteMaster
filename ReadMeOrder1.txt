6/29
ExtraServicesDetails partial view 
[v] add ExtraServicesDetails Dto
[v] add ExtraServicesDetailsDapperRepository 
[v] add ExtraServicesDetailsVM
[v] add ExtraServicesDetails function on Ordercontroller >>partial view

[v]fix the extraservicedetails bug

6/29 8:51
AccomodationDetails partial view (useDapper)
[v] add Dto
[v] add interface, service
[v] add DapperRepository
[v] need to fix partial view bug 

6/30 00:40am
[v] fixed partial view bug 
[v] ActivitiesDetails use Dapper (hide Entity Framework)
[v] ExtraServicesDetails use Dapper (hide Entity Framework)

6/30 4:50pm
[v] Delete ActivitiesDetails controller (useless)
[v] Delete ExtraServicesDetails controller (useless)
[v] Add PaymentStatusText on OrderIndexVM 1=已付款, 2=未付款, 3=已取消
[v] Adjust orderIndex format
[v] Add search (membername, paymentstatus, createdate)


7/1
[v] Add criteria, create membername and paymentstatus search list
[V] Add select data on orderindex
[v] Add query data on OrderEFRepository

[v] Add querycreatedatedata on OrderEFRepository
[v] Add datepick

7/4
[v] add extraservice edit
[v] add accomodation edit (dto,interface,services,dapper,exts,view)
[v] add activity edit(dto,interface,service,dapper,exts,view)
[v] add  delete function on accomodationdetails,activitiesDetails,ExtraServicesDetails

7/5
[v] add paymentmethod CRUD function

7/6
[v] export file but only can export to CSV.file, can't export to xlsx, will figure it out when have more time.
[v] Add Detail's order total price 

7/7
[v] checkboxall done ; checkbox(multiple check not yet)
[v] Send UnPaidNotification to customers 