import {
  Grid,
  GridToolbar,
  GridColumn as Column,
} from "@progress/kendo-react-grid";
import React, { useEffect, useState } from "react";
import { CommandCell as GridCommandCell } from "../Component/CommandCell";
import axios from "axios";
import { DropDownList } from "@progress/kendo-react-dropdowns";
import { FormControl } from "react-bootstrap";
import { Dialog, DialogActionsBar } from "@progress/kendo-react-dialogs";

const baseUrl = "https://localhost:7000";
const pageSize = 30;

function OrderItem(props) {
  const {orderDetails, setOrderDetails, orderItems, setOrderItems} = props;
  console.log("OrderItem --> orderDetails: ", orderDetails)
  // const [orderItems, setOrderItems] = useState([]);
  const [itemCodes, setItemCodes] = useState([]);
  const [itemDescs, setItemDescs] = useState([]);
  const [showRemoveItemDialog, setShowRemoveItemDialog] = useState(false);
  const [dropDownSettingIc, setDropDownSettingIc] = useState({
    skip: 0,
    take: pageSize,
    filterText: "",
    total: 0,
  });
  const [removedItem, setRemovedItem] = useState({});
  const [dropDownSettingDesc, setDropDownSettingDesc] = useState({
    skip: 0,
    take: pageSize,
    filterText: "",
    total: 0,
  });
  const [index, setIndex] = useState(1);

  useEffect(() => {
    getStockItemDropDownData("Code");
    getStockItemDropDownData("Description1");
  }, []);

  const onTextChange = (event, dataItem) => {
    console.log("onTextChange value: ", event.target.value);
    console.log("onTextChange name: ", event.target.name);
    const items = [...orderItems];
    const selectedItems = items.filter((x) => x.index === dataItem.index);
    if(selectedItems.length > 0) {
      selectedItems[0][event.target.name] = event.target.value;
      if (selectedItems.length > 0) {
        console.log("onTextChange Calculation ");
        const x = selectedItems[0];
        if (x.quantity && x.price) {
          x.exclAmount = +x.quantity * +x.price;
        }
        if (x.exclAmount && x.tax) {
          x.taxAmount = (+x.exclAmount * +x.tax) / 100;
        }
        if (x.exclAmount && x.taxAmount) {
          x.inclAmount = +x.exclAmount + +x.taxAmount;
        }
      }
      setOrderItems(items);
    }
  };

  const calculateTotalAmountDetails = () => {
    let totalExcl = 0;
    let totalTax = 0;
    let totalIncl = 0;
    orderItems.forEach(x => {      
      if(x.exclAmount) {
        totalExcl += +x.exclAmount;
      }
      if(x.taxAmount){
        totalTax += +x.taxAmount;
      }
      if(x.inclAmount) {
        totalIncl +=  +x.inclAmount;
      }
    });
    let orderDetailsHere = {...orderDetails};
    orderDetailsHere.totalExcl = totalExcl;
    orderDetailsHere.totalTax = totalTax;
    orderDetailsHere.totalIncl = totalIncl
    setOrderDetails(orderDetailsHere);
  };

  const getStockItemDropDownData = (field) => {
    let skip = 0;
    let take = 0;
    let filterText = "";
    if (field === "Code") {
      skip = dropDownSettingIc.skip;
      take = dropDownSettingIc.take;
      filterText = dropDownSettingIc.filterText;
    } else if (field === "Description1") {
      skip = dropDownSettingDesc.skip;
      take = dropDownSettingDesc.take;
      filterText = dropDownSettingDesc.filterText;
    }
    console.log(`getStockItemDropDownData --> ${field} --> skip: ${skip}`);
    console.log(`getStockItemDropDownData --> ${field} --> take: ${take}`);
    console.log(
      `getStockItemDropDownData --> ${field} --> filterText: ${filterText}`
    );
    axios
      .get(
        `${baseUrl}/api/v1/StkItem/getStkItemIdCodeDesc/${field}/${skip}/${take}?filterText=${filterText}`
      )
      .then((response) => {
        console.log("getStockItemDropDownData: ", response.data);
        if (field === "Code") {
          setItemCodes(response.data.list);
          const ddsIc = dropDownSettingIc;
          ddsIc.total = response.data.total;
          setDropDownSettingIc(ddsIc);
        } else if (field === "Description1") {
          setItemDescs(response.data.list);
          const ddsDesc = dropDownSettingDesc;
          ddsDesc.total = response.data.total;
          setDropDownSettingDesc(ddsDesc);
        }
      })
      .catch((err) => {
        console.log("error: ", err);
      });
  };

  const DropDownCellItemCode = (props) => {
    console.log("DropDownCellItemCode --> props: ", props);
    const { dataItem } = props;
    return (
      <td>
        <DropDownList
          // style={{
          //   width: "300px",
          // }}
          data={itemCodes}
          textField={"text"}
          dataItemKey={"value"}
          onChange={(event) => handleSelectChange(event, "Code", dataItem)}
          filterable={true}
          onFilterChange={(event) => onFilterChange(event, "Code")}
          virtual={{
            total: dropDownSettingIc.total,
            pageSize: dropDownSettingIc.take,
            skip: dropDownSettingIc.skip,
          }}
          onPageChange={(event) => pageChange(event, "Code")}
          popupSettings={{
            height: "250px",
          }}
          value={dataItem.selectedItemCode}
        />
      </td>
    );
  };

  const toggleItemRemoveDialog = (dataItem) => {
    if(dataItem?.index) {
      setRemovedItem(dataItem);
    }
    setShowRemoveItemDialog(!showRemoveItemDialog);
  };

  const DropDownCellDesc = (props) => {
    const { dataItem } = props;
    return (
      <td>
        <DropDownList
          // style={{
          //   width: "300px",
          // }}
          data={itemDescs}
          textField={"text"}
          dataItemKey={"value"}
          onChange={(event) =>
            handleSelectChange(event, "Description1", dataItem)
          }
          filterable={true}
          onFilterChange={(event) => onFilterChange(event, "Description1")}
          virtual={{
            total: dropDownSettingDesc.total,
            pageSize: dropDownSettingDesc.take,
            skip: dropDownSettingDesc.skip,
          }}
          onPageChange={(event) => pageChange(event, "Description1")}
          popupSettings={{
            height: "250px",
          }}
          value={dataItem.selectedDesc}
        />
      </td>
    );
  };

  const handleSelectChange = (selectedOption, field, dataItem) => {
    console.log("handleSelectChange --> order Items: ", orderItems);
    console.log(`handleSelectChange --> field: ${field}`);
    console.log("handleSelectChange --> selectedOption: ", selectedOption);
    console.log("handleSelectChange --> dataItem: ", dataItem);
    const itemId = selectedOption?.value?.value;
    getItemDetails(itemId, dataItem);
    const items = [...orderItems];
    const selectedItems = items.filter((x) => x.index === dataItem.index);
    if (field === "Code") {
      if (selectedItems.length > 0) {
        selectedItems[0].selectedItemCode = selectedOption?.value;
        const stkItems = itemDescs.filter(
          (x) => x.value === selectedOption?.value?.value
        );
        if (stkItems.length > 0) {
          selectedItems[0].selectedDesc = stkItems[0];
        }
      }
    } else if (field === "Description1") {
      if (selectedItems.length > 0) {
        selectedItems[0].selectedDesc = selectedOption?.value;
        const stkItems = itemCodes.filter(
          (x) => x.value === selectedOption?.value?.value
        );
        if (stkItems.length > 0) {
          selectedItems[0].selectedItemCode = stkItems[0];
        }
      }
    }
    setOrderItems(items);
  };

  const getItemDetails = (itemId, dataItem) => {
    axios
      .get(`${baseUrl}/api/v1/stkItem/getStockItem/${itemId}`)
      .then((response) => {
        console.log("getItemDetails: ", response.data);
        const items = [...orderItems];
        const selectedItems = items.filter((x) => x.index === dataItem.index);
        if (selectedItems.length > 0) {
          selectedItems[0].price = response?.data?.purchaseAccount;
          const x = selectedItems[0];
          if (x.quantity && x.price) {
            x.exclAmount = +x.quantity * +x.price;
          }
          if (x.exclAmount && x.tax) {
            x.taxAmount = (+x.exclAmount * +x.tax) / 100;
          }
          if (x.exclAmount && x.taxAmount) {
            x.inclAmount = +x.exclAmount + +x.taxAmount;
          }
        }
        setOrderItems(items);
      })
      .catch((err) => {
        console.log("error: ", err);
      });
  };

  const onFilterChange = (event, field) => {
    console.log("onFilterChange --> field: ", field);
    console.log("onFilterChangeIc --> filter: ", event.filter);
    const filterText = event.filter.value;

    if (field === "Code") {
      const dds = dropDownSettingIc;
      dds.filterText = filterText;
      setDropDownSettingIc(dds);
      getStockItemDropDownData("Code");
    } else if (field === "Description1") {
      const ddsDesc = dropDownSettingDesc;
      ddsDesc.filterText = filterText;
      setDropDownSettingDesc(ddsDesc);
      getStockItemDropDownData("Description1");
    }
  };

  const pageChange = (event, field) => {
    console.log("pageChangeIc event: ", event);
    const skip = event.page.skip;
    const take = event.page.take;

    if (field === "Code") {
      const dds = dropDownSettingIc;
      dds.skip = skip;
      dds.take = take;
      setDropDownSettingIc(dds);
      getStockItemDropDownData("Code");
    } else if (field === "Description1") {
      const ddsDesc = dropDownSettingDesc;
      ddsDesc.skip = skip;
      ddsDesc.take = take;
      setDropDownSettingDesc(ddsDesc);
      getStockItemDropDownData("Description1");
    }
  };

  const CommandCell = (props) => (
    <GridCommandCell
      {...props}
      remove={remove}
      showDialog={toggleItemRemoveDialog}
    />
  );

  useEffect(() => {    
    calculateTotalAmountDetails();
  }, [orderItems])

  const remove = () => {
    const items =[...orderItems];
    console.log("remove --> before items: ", items);
    let index = items.findIndex((record) => record.index === removedItem.index);
    items.splice(index, 1);
    console.log("remove --> after items: ", items);
    setOrderItems(items);    
    setShowRemoveItemDialog();
  };

  const itemChange = (event) => {

  };

  const addNew = () => {
    const i = index;
    setIndex(index + 1);
    const newOrderItem = {
      index: i,
      itemId: "",
      itemCode: "",
      selectedItemCode: {},
      description: "",
      selectedDesc: {},
      note: "",
      quantity: null,
      price: null,
      tax: null,
      exclAmount: null,
      taxAmount: null,
      inclAmount: null,
    };
    setOrderItems([newOrderItem, ...orderItems]);
  };

  return (
    <div className="container mt-3 mb-3">
      <Grid
        data={orderItems}
        onItemChange={itemChange}
        dataItemKey={"index"}
      >
        <GridToolbar>
          <button
            title="Add new"
            className="k-button k-button-md k-rounded-md k-button-solid k-button-solid-primary"
            onClick={addNew}
          >
            Add new
          </button>
        </GridToolbar>
        <Column field="index" title="#" width="35px" editable={false} />
        <Column
          field="iteCode"
          title="Item Code"
          width="130px"
          cell={DropDownCellItemCode}
        />
        <Column
          field="description1"
          title="Description"
          width="130px"
          cell={DropDownCellDesc}
        />
        <Column
          field="note"
          title="Note"
          width="130px"
          cell={(props) => {
            const { dataItem } = props;
            return (
              <td>
                <FormControl
                  as="textarea"
                  type="note"
                  name="note"
                  value={dataItem.note}
                  onChange={(event) => onTextChange(event, dataItem)}
                  className="form-control"
                  rows="2"
                />
              </td>
            );
          }}
        />
        <Column
          field="quantity"
          title="Quantity"
          editor="numeric"
          width="100px"
          cell={(props) => {
            const { dataItem } = props;
            return (
              <td>
                <FormControl
                  type="quantity"
                  name="quantity"
                  value={dataItem.quantity}
                  onChange={(event) => onTextChange(event, dataItem)}
                  className="form-control"
                />
              </td>
            );
          }}
        />
        <Column field="price" title="Price" width="100px" editor="numeric" />
        <Column
          field="tax"
          title="Tax"
          editor="numeric"
          width="80px"
          cell={(props) => {
            const { dataItem } = props;
            return (
              <td>
                <FormControl
                  type="tax"
                  name="tax"
                  value={dataItem.tax}
                  onChange={(event) => onTextChange(event, dataItem)}
                  className="form-control"
                />
              </td>
            );
          }}
        />
        <Column field="exclAmount" title="Excl Amount" width="100px" />
        <Column field="taxAmount" title="Tax Amount" width="100px"/>
        <Column field="inclAmount" title="Incl Amount" width="100px"/>
        <Column cell={CommandCell} width="80px" />
      </Grid>
      {showRemoveItemDialog && (
        <Dialog title={"Please confirm"} onClose={toggleItemRemoveDialog}>
        <p
          style={{
            margin: "25px",
            textAlign: "center",
          }}
        >
          Are you sure you want to continue?
        </p>
        <DialogActionsBar>
          <button
            className="k-button k-button-md k-rounded-md k-button-solid k-button-solid-base"
            onClick={toggleItemRemoveDialog}
          >
            No
          </button>
          <button
            className="k-button k-button-md k-rounded-md k-button-solid k-button-solid-primary"
            onClick={remove}
          >
            Yes
          </button>
        </DialogActionsBar>
      </Dialog>
      )}
    </div>
  );
}

export default OrderItem;
