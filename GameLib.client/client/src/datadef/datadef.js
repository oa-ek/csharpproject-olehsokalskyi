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
        {name: 'imagePath', validator: 'required: true', isPhoto: true},
        {name: 'price', validator: 'required: true', isNumber: true},
        {name: 'trailer', validator: 'required: true'},
        {name: 'releaseDate', validator: 'required: true'},
        {name: 'genresList' , validator: 'required: true', isMultySelect: true, entityurl: 'genre', visibleFields: ['id','title'], otherName:
            'genres'},
        {name: 'platformsList' , validator: '', isMultySelect: true, entityurl: 'platform', visibleFields: ['id','title'], otherName: 'platforms'},
        {name: 'publisherId', validator: 'required: true', isSelect: true, entityurl: 'publisher', visibleFields: ['id','title'], otherName: 'publisher'},
        {name: 'developersList', validator:  '', isMultySelect: true, entityurl: 'developer', visibleFields: ['id','title'], otherName: 'developers'},
        {name: 'languagesList', validator:  '', isMultySelect: true, entityurl: 'language', visibleFields: ['id','title'], otherName: 'languages'},
    ],
    achievement: [
        {name: 'id', validator: 'required: true'},
        {name: 'title', validator: 'required: true'},
        {name: 'description', validator: 'required: true'},
        {name: 'gameId', validator: 'required: true', isSelect: true, entityurl: 'game', visibleFields: ['id','title']},

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
        {name: 'imagePath', label: 'Image'},
        {name: 'price', label: 'Price'},
        {name: 'trailer', label: 'Trailer'},
        {name: 'releaseDate', label: 'Release Date'},
        {name: 'genres', label: 'Genres List'},
        {name: 'platforms', label: 'Platforms List'},
        {name: 'publisher', label: 'Publisher ID'},
        {name: 'developers', label: 'Developers List'},
        {name: 'languages', label: 'Languages List'},
        {name: 'ratings', label:'Ratings'},
        {name: 'achievements', label:'Achievements'},
        {name: 'players', label: 'Players'}
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
    rating : [
        {name: 'id', label: 'ID'},
        {name: 'ratingValue', label: 'Rating', isStar: true},
        {name: 'comment', label: 'Comment'},
        {name: 'date', label: 'Date'},
        {name: 'game', label: 'Game', isObject: true, objFields: [ 'title']},
        {name: 'user', label: 'User', isObject: true, objFields: ['email']}
    ],
    achievementUser: [
        {name: 'id', label: 'ID'},
        {name: 'achievement', isObject: true, objFields: ['title']},
        {name: 'user', isObject: true, objFields: ['userName']}
    ],
    user:[
        {name: 'id', label: 'ID'},
        {name: 'email', label: 'Email'},
        {name: 'role', label: 'Role', isObject: true, objFields: ['name']},
    ]
};