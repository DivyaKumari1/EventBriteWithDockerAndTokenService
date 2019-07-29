
**This document contains the general structure of an event Item**
</br>
</br>
General guidlines: </br>
Take information from a real event--then the images and url are already there for you. 
</br>
</br>
Below is an example for the TedX seattle event in November </br>
TedEx Seattle Nov </br>
<pre>
new EventItem() { EventCategoryId=3, 
                    EventVenueId=6, 
                    EventStartDateId=1,
                    EventDescription="Talks on a moment of change from one position to another,
                    whether it be in relationships, beliefs, cultures, perspectives or the world",</br> 
                    EventName="TEDxSeattle 2019: SHIFT",</br>
                    EventCost=20.00m,  //note you have to add the m suffix when declaring a decimal.</br>
                    EventAddress="321 Mercer St",</br>
                    EventCity="Seattle",</br> 
                    EventState="Washington",</br>
                    EventZip=98109,</br> 
                    EventFavorite=false,</br> 
                    EventTicketsAvailable=100 , </br>
                    EventStartTime="8:00", </br>
                    EventEndDate="11/23/19",</br>
                    EventEndTime="17:00"</br>
                    EventPictureUrl="http://replace/TedEx_SHIFT_2019.PNG",</br>
                    EventUrl="https://tedxseattle.com/"
                    }

</pre> 

**Below is a blank item that you can use to create an EventItem**
<pre>
new EventItem() { EventCategoryId=  , EventVenueId=  , EventStartDateId= , EventDescription=  , EventName=   , EventCost=   , EventAddress= , EventCity=  , EventState=  , EventZip=  , EventFavorite= , EventTicketsAvailable= , EventStartTime=  ,  EventEndDate= ,  EventEndTime=  , EventPictureUrl=  , EventUrl= }

</pre>


**Assign a category by using one the corresponding numbers for the venues:**
//(Music, Food & Drink ,  Seminars, Kids, Drama, Outdoor, Dance) 
new EventCategory() {Category = "Music"},  1   </br>
new EventCategory() {Category = "Food & Drink"}, 2  </br>
new EventCategory() {Category = "Seminars" },  3    </br>
new EventCategory() {Category = "Film & Media"}, 4  </br>
new EventCategory() {Category = "Kids" },  5  </br>
new EventCategory() {Category = "Other"} 6   </br>

So, if you have a music category you would add use EventCategory=1

**Below is the EventVenue Domain**
<pre>
new EventVenue() {Venue= "Chateau Ste Michelle"},  1
new EventVenue() {Venue= "Neumos"},      2
new EventVenue() {Venue= "Lauren Ashton Cellars"}, 3
new EventVenue() {Venue= "Magnussen Park Hangar 30"}, 4
new EventVenue() {Venue= "Bottle House Seattle"}, 5
new EventVenue() {Venue= "McCaw Hall"} 6
</pre>


**Below is the EventStartDate Domain**
<pre>
new EventStartDate() {StartDate = "11/23/19" },  1
new EventStartDate() {StartDate = "7/14/19"},  2
new EventStartDate() {StartDate = "8/22/19"},  3
new EventStartDate() {StartDate = "7/27/19"},  4
new EventStartDate() {StartDate = "8/4/19"},  5
new EventStartDate() {StartDate = "9/6/19"}  6
</pre>



