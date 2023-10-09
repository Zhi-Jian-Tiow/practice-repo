export interface Item {
  id: string;
  item: string;
  checked: boolean;
}

export default class ListItem implements Item {
  constructor(
    private _id: string = "",
    private _item: string = "",
    private _checked: boolean = false
  ) {}

  get id() {
    return this._id;
  }

  get item() {
    return this._item;
  }

  get checked() {
    return this._checked;
  }

  set id(newId: string) {
    this._id = newId;
  }

  set item(newItem: string) {
    this._item = newItem;
  }

  set checked(newChecked: boolean) {
    this._checked = newChecked;
  }
}
