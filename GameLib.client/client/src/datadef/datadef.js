export const fields = {
    genre : [
        {name: 'id', validator: 'required: true'},
        {name: 'title', validator: 'required: true'}
    ],
    platform : [
        {name: 'id', validator: 'required: true'},
        {name: 'title', validator: 'required: true'}
    ],
    developer: [
        {name: 'id', validator: 'required: true'},
        {name: 'title', validator: 'required: true'},
        {name: 'description', validator: 'required: true'}
    ],
    game: [
        {name: 'id', validator: 'required: true'},
        {name: 'title', validator: 'required: true'},
        {name: 'description', validator: 'required: true'},
        {name: 'image', validator: 'required: true'},
        {name: 'price', validator: 'required: true'},
        {name: 'trailer', validator: 'required: true'},
        {name: 'releaseDate', validator: 'required: true'},
    ],
    achievement: [
        {name: 'id', validator: 'required: true'},
        {name: 'title', validator: 'required: true'},
        {name: 'description', validator: 'required: true'},
        {name: 'gameId', validator: 'required: true', isSelect: true, url: 'https://localhost:7226/api/game/list'},

    ],
    player: [
        {name: 'id', validator: 'required: true'},
        {name: 'firstName', validator: 'required: true'},
        {name: 'lastName', validator: 'required: true'},
        {name: 'userName', validator: 'required: true'},
        {name: 'email', validator: 'required: true'},
    ],
    role: [
        {name: 'id', validator: 'required: true'},
        {name: 'name', validator: 'required: true'},
    ],
};

export const displayFields = {
    genre : [
        {name: 'id', label: 'ID'},
        {name: 'title', label: 'Title'}
    ],
    platform : [
        {name: 'id', label: 'ID'},
        {name: 'title', label: 'Title'}
    ],
    developer: [
        {name: 'id', label: 'ID'},
        {name: 'title', label: 'Title'},
        {name: 'description', label: 'Description'}
    ],
    game: [
        {name: 'id', label: 'ID'},
        {name: 'title', label: 'Title'},
        {name: 'description', label: 'Description'},
        {name: 'image', label: 'Image'},
        {name: 'price', label: 'Price'},
        {name: 'trailer', label: 'Trailer'},
        {name: 'releaseDate', label: 'Release Date'},
    ],
    publisher: [
        {name: 'id', label: 'ID'},
        {name: 'title', label: 'Title'},
        {name: 'description', label: 'Description'},
    ],
    achievement: [
        {name: 'id', label: 'ID'},
        {name: 'title', label: 'Title'},
        {name: 'description', label: 'Description'},
        {name: 'gameTitle', label: 'Game Title'},
        {name: 'playersGet', label: 'Players Get'},
        {name: 'gameId', label: 'Game ID', isHide: true},
    ],
    player: [
        {name: 'id', label: 'ID'},
        {name: 'firstName', label: 'First Name'},
        {name: 'lastName', label: 'Last Name'},
        {name: 'userName', label: 'User Name'},
        {name: 'email', label: 'Email'},
    ],
    role: [
        {name: 'id', label: 'ID'},
        {name: 'name', label: 'Name'},
    ],
};