export interface Mark {
    id: string
    lessonMark: string
}

export interface Group {
    id: string
    title: string
    educationalInstitutionId: string
    teacherId: string
}

export interface AbsentPupil {
    educationalInstitutionId: string
    datetimemark: string
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
    educInstId: string
}

export interface Pupil {
    id: string
    groupId:string
}

export interface ParentPupil {
    relationship: string
    parentId: string
    pupilId:string
}

export interface Device {
    id: string
    educationalInstitutionId :string
}

export interface EducationalInstitution {
    id: string
    title: string
    address: string
    timetable: string
}

export interface Lesson {
    dateofstart: string
    dateoffinish: string
    audience: string
    description: string
    teacherId: string
    educInstId: string
    strGroupsId: string
}