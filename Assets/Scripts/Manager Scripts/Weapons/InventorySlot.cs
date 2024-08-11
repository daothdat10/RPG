using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class InventorySlot { 
    private Stack<IIventoryItem> mItemStack = new Stack<IIventoryItem>();

    private int mId = 0;

    public InventorySlot(int id)
    {
        mId = id;
    }
    public int Id {  get { return mId; } }

    public void AddItem(IIventoryItem item)
    {
        item.Slot = this;
        mItemStack.Push(item);
    }

    public InventoryItemBase FirstItem {
        get
        {
            if(isEmpty)
                   return null;

            return (InventoryItemBase)mItemStack.Peek();
        }
    }

    public bool IsStackable(IIventoryItem item)
    {
        if (isEmpty)
            return false;

        InventoryItemBase first = (InventoryItemBase)mItemStack.Peek();

        if(first.Name == item.Name)
            return true;

        return false;
    }

    public bool isEmpty
    {
        get { return Count == 0; }
    }
    public int Count
    {

        get { return mItemStack.Count; }
    }

    public bool Remove(InventoryItemBase item)
    {
        if (isEmpty)
        {
            return false;
        }

        InventoryItemBase first = (InventoryItemBase)mItemStack.Peek();
        if(first.Name == item.Name)
        {
            mItemStack.Pop();
            return true;
        }
        return false;

    }

    public static implicit operator InventorySlot(InvenStorySlot v)
    {
        throw new NotImplementedException();
    }
}
