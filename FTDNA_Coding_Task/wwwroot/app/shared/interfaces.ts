

export interface ISample {
    barcode: string,
    createdAt: string,
    firstName: string,
    lastName: string,
    sampleId: string,
    status: string
}

export interface ISampleRequest {
    Barcode: string,
    CreatedBy: string,
    StatusId: string
}

export interface IUser {
    Id: string,
    UserName: string
}

export interface IStatus {
    Id: string,
    Status: string
}
