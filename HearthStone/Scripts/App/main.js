
var ROOT = '/PlayHearthStone';
var game = $.connection.gameHub;
var playerName;

function LoadDeck() {
    var value = $('#deck-content')[0].value;
    $.post(ROOT + "/api/game/loaddeck", { '': value }, function () {
        $('.command-panel').addClass("closed");

        // draw 5 cards
        $.get(ROOT + "/api/game/drawcard", addCardOnHand);
        $.get(ROOT + "/api/game/drawcard", addCardOnHand);
        $.get(ROOT + "/api/game/drawcard", addCardOnHand);
        $.get(ROOT + "/api/game/drawcard", addCardOnHand);
        $.get(ROOT + "/api/game/drawcard", addCardOnHand);

        // Store player name
        playerName = $("#player-name")[0].value;
    });
}

function DrawCard() {
    $.get(ROOT + "/api/game/drawcard", addCardOnHand);
}

function addCardOnHand(card) {
    $('#hand-panel').append("<img src='" + card + "' class='card'></img>");

    $(".card").draggable({
        cursor: "grabbing",
        cursorAt: { top: -5, left: -5 },
        helper: function (event) {
            //console.log(event.target.src);
            return $("<img src='" + event.target.src + "' class='grab-card'/>");
        }
    });
}

function playCard(card) {
    $('#my-board').append(card[0]);

    game.server.playCard(playerName, card[0].src);
}

function removeCard(card) {
    card.remove();
}

// Create a function that the hub can call to broadcast messages.
game.client.broadcastMessage = function (name, message) {

    // Html encode display name and message. 
    //var encodedName = $('<div />').text(name).html();
    //var encodedMsg = $('<div />').text(message).html();

    // Add the message to the page. 
    $('#discussion').append('<li><strong>' + name + '</strong>' + message + '</li>');
};

game.client.CardPlayed = function (owner, cardUrl) {

    if (owner != playerName) {
        var img = $("<img>");
        img.attr('src', cardUrl);
        img.addClass("card");
        $('#ennemy-board').append(img);
    }
}

$.connection.hub.start();

$(function () {

    // Make zone droppable
    $("#my-board").droppable({
        activeClass: "ui-state-active",
        hoverClass: "ui-state-hover",
        drop: function (event, ui) {
            playCard(ui.draggable);
        }
    });

    // Make trash droppable
    $("#trash").droppable({
        activeClass: "ui-state-active",
        hoverClass: "ui-state-hover",
        drop: function (event, ui) {
            removeCard(ui.draggable);
        }
    });

});

