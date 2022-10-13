import { UserModel } from "./user";

export interface ShortedUrl {
    id: number,
    url: string,
    shortedUrl: string,
    createdDate: Date,
    createdBy: UserModel
}
