import { ShortedUrl } from "./shortedUrl";

export interface UserModel {
    id: number,
    login: string,
    password: string,
    role: number,
    fullName: string,
    ownedUrls: ShortedUrl[]
}
