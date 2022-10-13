import { UserModel } from "./user";

export interface ShortedUrl {
    id: number,
    url: string,
    shortUrl: string,
    createdDate: Date,
    createdById: number
}
