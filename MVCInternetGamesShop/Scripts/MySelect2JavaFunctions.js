GameCategory = function (gameId, categoryId) {
    this.GameID = gameId;
    this.CategoryID = categoryId;
}
$(document).ready(function () {
    var GameId = $('#game-id-for-js').attr("data-id");
    var listOfCurrentCategories = getCurrentListOfCategoriesIds(GameId);
    
    $('#test').on("select2:unselect", function (e) {       
        var dataToDeleteString = e.params.data.id;
        var dataToDelete = parseInt(dataToDeleteString);        
        if (IsCategoryExistsInDb(dataToDelete, listOfCurrentCategories)) {
            deleteCategoryFormDatabase(GameId, dataToDelete);
            //listOfCurrentCategories = listOfCurrentCategories.filter(c => c !== dataToDelete);
            //alert(listOfCurrentCategories);
        }
        else {
            
            alert("kategorii, którą chcesz usunąć nie ma w bazie!");
        }
        

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
    return found;
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
           // alert("błąd ajax")
        },

        complete: function (data) {
             $("#test").select2(
             ).val(responseFromServer).change();
             
             
        }

    });
    return responseFromServer;
};


deleteCategoryFormDatabase = function (gameId, deletedCategoryId) {
    //alert("usunięto Id = " + deletedCategoryId);
    gameCategory = new GameCategory(gameId, deletedCategoryId);
    $.ajax({
        type: 'POST',
        url: "/Games/deleteCategoryFromDatabase/",
        data: gameCategory,
        success: function (response) {
            alert(response + "usunięto z bazy danych");
        },
        error: function (n) {
            alert("coś nie tak ajax post")
        }
    })
};

addCategoryToDatabase = function (gameId, addedCategoryId) {
    alert("dodano Id = " + addedCategoryId);
};
    










    

    

