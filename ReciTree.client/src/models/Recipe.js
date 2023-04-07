import { Profile } from "./Account"

export class Recipe {
    constructor(data) {
        this.id = data.id
        this.name = data.name
        this.instructions = data.instructions
        this.instructionsPic = data.instructionsPic
        this.creatorId = data.creatorId
        this.img = data.img
        this.creator = new Profile(data.creator)
        this.category = data.category
        this.isPrivate = data.isPrivate
    }
}