export default interface IAsset {
    id: number;
    notes: string;
    make: string;
    model: string;
    serial: string;
    partNumber: string;
    price: number;
    purchaseDate: Date;
    warrantyExpiration: Date;
    createdAt: Date;
    updatedAt: Date;
    conditionName: string;
    locationName: string;
    assetTypeName: string;
    statusName: string;
}