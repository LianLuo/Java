package com.mhl.models;

public class EmployeeModel extends Entity{

	private String number;
	private String userName;
	private boolean gender;
	private DepartmentModel depModel;
	private OfficeModel officeModel;
	private String remark;
	
	
	public String getNumber() {
		return number;
	}
	public void setNumber(String number) {
		this.number = number;
	}
	public String getUserName() {
		return userName;
	}
	public void setUserName(String userName) {
		this.userName = userName;
	}
	public boolean isGender() {
		return gender;
	}
	public void setGender(boolean gender) {
		this.gender = gender;
	}
	public DepartmentModel getDepModel() {
		return depModel;
	}
	public void setDepModel(DepartmentModel depModel) {
		this.depModel = depModel;
	}
	public OfficeModel getOfficeModel() {
		return officeModel;
	}
	public void setOfficeModel(OfficeModel officeModel) {
		this.officeModel = officeModel;
	}
	public String getRemark() {
		return remark;
	}
	public void setRemark(String remark) {
		this.remark = remark;
	}
}
