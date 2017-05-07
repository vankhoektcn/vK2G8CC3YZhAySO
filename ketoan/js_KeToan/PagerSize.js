// JScript File

var currentPage="";

function DeleteNumPage()
{
    $("#PageSize").empty();
}
function CreatePager(ItemCount,ArrayPage)
{
    DeleteNumPage();
    var TotalItem = ArrayPage.split('|');
   // var ItemCount  = 100;
   //  alert(TotalItems.length);
    
    var PageNum = Math.round((TotalItem.length)/eval(ItemCount));
    var html = "";
    for(var page=1;page<=PageNum;page++)
    {
        html +=" <label id=\"page_"+page+"\" style=\"cursor:pointer\" onclick=\"ShowPage(this.id,'"+ItemCount+"','"+ArrayPage+"')\">["+page+"]</label>"; 
    }
     $("#PageSize").append(html);
  // ShowPage("page_1");
  var Array = ShowArrayItem("1",ItemCount,ArrayPage);
  return Array;
}

function ShowArrayItem(num_page,ItemCount,ArrayPage)
{
      var TotalItem = ArrayPage.split('|');
      var itemfirst = eval(ItemCount)*(eval(num_page)-1)+1;
      var ArrayItem="";
      var Item_Count="";
      if(ItemCount>TotalItem.length)
        Item_Count = TotalItem.length-1;
      else
        Item_Count = ItemCount;
      for(var i=0;i<Item_Count;i++)
      {
         ArrayItem +="|"+(itemfirst+i)+"&"+ TotalItem[itemfirst+i];
      }
    return ArrayItem;
}