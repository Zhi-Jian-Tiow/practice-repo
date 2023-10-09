import ListItem from "./ListItem";

interface List {
  itemList: ListItem[];
  load(): void;
  save(): void;
  clear(): void;
  addItem(itemObj: ListItem): void;
  removeItem(id: string): void;
}

export default class FullList implements List {
  static instance: FullList = new FullList();
  private constructor(private _itemList: ListItem[] = []) {}

  get itemList(): ListItem[] {
    return this._itemList;
  }

  load(): void {
    const storedList: string | null = localStorage.getItem("myList");
    if (typeof storedList !== "string") return;

    const parsedList: { _id: string; _item: string; _checked: boolean }[] =
      JSON.parse(storedList);

    parsedList.forEach((itemObj) => {
      const newListItem = new ListItem(
        itemObj._id,
        itemObj._item,
        itemObj._checked
      );
      FullList.instance.addItem(newListItem);
    });
  }

  save(): void {
    localStorage.setItem("myList", JSON.stringify(this._itemList));
  }

  clear(): void {
    this._itemList = [];
    this.save();
  }

  addItem(newItem: ListItem): void {
    this._itemList.push(newItem);
    this.save();
  }

  removeItem(id: string): void {
    this._itemList = this._itemList.filter((item) => item.id !== id);
    this.save();
  }
}
