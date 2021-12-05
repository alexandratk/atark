export interface Group {
    id: string
    title: string
    educationalInstitutionId: string
    teacherId: string
}

export interface User {
    id:string
    role:string
    login: string
    password: string
}

export interface UserData {
    id: string
    role: string
    jwtToken: string
    name: string
    dateofbirth: string
} 

export interface UserRegister {
    id:string
    role:string
    login: string
    password: string
    jwtToken: string
    name: string
    dateofbirth: string
    educationalInstitutionId: string
}

export interface Pupil {
    id: string
    groupId:string
}