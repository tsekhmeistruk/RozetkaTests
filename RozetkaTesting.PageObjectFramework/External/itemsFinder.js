function replace(value){
	return value.textContent.replace(/[\n\r\t\NEW]/g,'');
}

var cells = document.querySelectorAll("ul[id='m-main'] > li >a"); 
var arrayItems = [];
for(i=0; i<cells.length; i++) {
  var item = {};
	item.topic = replace(cells[i]);
  item.url = cells[i].href;
  
  item.subItems = [];
  var subCells = document.querySelectorAll("ul[id='m-main'] > li:nth-of-type(" + (i+1) + ") .m-main-subl > li > a");
  for(j=0; j<subCells.length; j++){
    var subItem = {};
    subItem.subTopic = replace(subCells[j]);
    subItem.subUrl = subCells[j].href;
    item.subItems[j] = subItem;
    
    subItem.subSubItems = [];
    var subSubCells = document.querySelectorAll("ul[id='m-main'] > li:nth-of-type("+ (i+1) +") .m-main-subl > li.m-main-l-i:nth-of-type("+ (j+1) +") ul.m-menu-third-l > li > a");
    for(k=0; k<subSubCells.length; k++){
      var subSubItem = {};
      subSubItem.subSubTopic = replace(subSubCells[k]);
      subSubItem.subSubUrl = subSubCells[k].href;
      subItem.subSubItems[k] = subSubItem;
    }
  }  
  arrayItems[i] = item;
};
JSON.stringify(arrayItems, undefined, 4);