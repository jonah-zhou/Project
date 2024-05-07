package data;

public class CellTag {
    private int backgroundResource;
    private String cellType;

    public CellTag(int backgroundResource, String cellType) {
        this.backgroundResource = backgroundResource;
        this.cellType = cellType;
    }

    public CellTag(int backgroundResource){
        this.backgroundResource = backgroundResource;
    }

    public String getCellType() {
        return cellType;
    }

    public void setCellType(String cellType){
        this.cellType = cellType;
    }

    public int getBackgroundResource() {
        return backgroundResource;
    }

    public  void setBackgroundResource(int backgroundResource){
        this.backgroundResource = backgroundResource;
    }

}

