


export class Ingredient {
    constructor(data) {
        this.id = data.id
        this.name = data.name
        this.measurement = data.measurement
        this.quantity = data.quantity
        this.recipeId = data.recipeId
    }
}