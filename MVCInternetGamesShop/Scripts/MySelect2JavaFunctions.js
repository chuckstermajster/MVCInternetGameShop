$(document).ready(function () {    
    var GameId = $('#game-id-for-js').attr("data-id");
    var listOfCurrentCategories = getCurrentListOfCategoriesIds(GameId);
    alert(GameId);
    
    

    
        
   
    
    $('#test').on("select2:unselect", function (e) {       
        
        
        
        var dataToDeleteString = e.params.data.id;
        var dataToDelete = parseInt(dataToDeleteString);
        
        IsCategoryExistsInDb(dataToDelete, listOfCurrentCategories);
        alert(dataToDelete);

    });    
    $('#test').on("select2:select", function (e) {
        var categoryIdToAdd = e.params.data.id;
        
        console.log(e);
        
    });    
});

IsCategoryExistsInDb = function (categoryId, CategorysInDb) {
    var found = false;
    for (var i = 0; i < CategorysInDb.length; i++) {
        if (CategorysInDb[i] === categoryId) {
            found = true;
            break;        }
    }
    console.log(found);
};

getCurrentListOfCategoriesIds = function (GameId) {
    var responseFromServer;
    $.ajax({
        type: 'GET',
        async: false,        
        url: "/Games/GetCurrentCategoriesIds/",
        data: { 'gameId': GameId },
        success: function (response) {
            responseFromServer = response.CurrentCategoriesId;
            
        },
        error: function (n) {
            alert("błąd ajax")
        },

        complete: function (data) {
             $("#test").select2(
             ).val(responseFromServer).change();
             
             
        }

    });
    return responseFromServer;
};


deleteCategoryFormDatabase = function (gameId, deletedCategoryId) {
    alert("usunięto Id = " + deletedCategoryId);
};

addCategoryToDatabase = function (gameId, addedCategoryId) {
    alert("dodano Id = " + addedCategoryId);
};
    










    

    

