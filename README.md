# ia-coding-challenge

Written in VS 2022 CE targetting .NET 6

➢ Please detail any assumptions you have made (it is recommended you make strong
assumptions and state them).

I made a lot of assumptions on variable size that I would likely not make in a production application because the numbers would likely need to be larger than was necessary for this application (lots of shorts that probably would become longs).

I didn't add a second sorting criteria for ties in distance.

I assumed a single medication at each fill site.

I assumed a cap of $99.99 for medication (mostly so the formatting of the results wouldn't exceed 4 digits).

➢ Provide a brief summary of how you might change your program if you needed to
support multiple central fills at the
same location?

The code is very close to be able to do this already. The `Location` object would just need to have a list of facilities instead of a single facility, the second `Select` statement in the LINQ expression in the `GetNearestFacilities` method would need to be `SelectMany` instead and the exception thrown from the duplication coordinate would have to handle adding the new facility to the Location's list.

➢ Provide a brief summary of how you would change your program if you were working
with a much larger world size?

I would change the `Map` object to be called `Sector` and allow sectors to contain a list of their own child sectors. I would have each sector automatically subdivide itself into 4 subsectors when it hit a configurable breakpoint (10 sites, for instance). When searching for sites, you would need to specify the max number of results you were looking for. The search would drill down recursively to find the sector with no child sectors that contained the search origin and then start searching adjacent sectors until the max number of sites was found (or a max distance).
