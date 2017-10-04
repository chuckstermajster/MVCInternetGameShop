GameCategory = function (gameId, categoryId) {
    this.GameID = gameId;
    this.CategoryID = categoryId;
}
$(document).ready(function () {
    $(window).on('popstate', function () {
        listOfCurrentCategories = getCurrentListOfCategoriesIds(GameId);
        $("#test").select2(
             ).val(listOfCurrentCategories).change();
    });
    var GameId = $('#game-id-for-js').attr("data-id");
    var listOfCurrentCategories = getCurrentListOfCategoriesIds(GameId);
    
    $('#test').on("select2:unselect", function (e) {
        
        var dataToDeleteString = e.params.data.id;
        var dataToDelete = parseInt(dataToDeleteString);    
       
        deleteCategoryFormDatabase(GameId, dataToDelete);
            
        
      
        

    });    
    $('#test').on("select2:select", function (e) {
        var IdToAddString = e.params.data.id;
        var IdToAdd = parseInt(IdToAddString);
        addCategoryToDatabase(GameId, IdToAdd);
        
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
            listOfCurrentCategories = responseFromServer;
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
    
    gameCategory = new GameCategory(gameId, deletedCategoryId);
    $.ajax({
        type: 'POST',
        url: "/Games/deleteCategoryFromDatabase/",
        data: gameCategory,
        success: function (response) {
            listOfCurrentCategories = response;
            console.log(listOfCurrentCategories);
        },
        error: function (n) {
            alert("coś nie tak ajax post")
        }
    });
};

addCategoryToDatabase = function (gameId, addedCategoryId) {
    gameCategory = new GameCategory(gameId, addedCategoryId);
    $.ajax({
        type: 'POST',
        url: "/Games/AddCategoryToDatabase/",
        data: gameCategory,
        success: function (response) {
            listOfCurrentCategories = response;
        },
        error: function (e) {
            alert("coś poszło nie tak")
        }

    });

    
};
    










    

    

